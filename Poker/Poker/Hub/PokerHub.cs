﻿using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using PokerClassLibrary;
using Poker.DataModel.Dto;
using Poker.DataModel;
using Microsoft.AspNetCore.SignalR;
using System;
using LinqToDB;

namespace Poker.Hubs
{
    public class PokerHub : Hub
    {
        private readonly PokerContext DbContext;
        private readonly IDictionary<string, string> ConnectionIds;
        private static readonly IDictionary<string, System.Timers.Timer> Timers = new Dictionary<string, System.Timers.Timer>();
        private readonly IHubContext<PokerHub> HubContext;
        private readonly int TimerInterval = 10000;

        public PokerHub
        (
            PokerContext dbContext,
            IDictionary<string, string> connectionIds,
            IHubContext<PokerHub> hubContext
        )
        {
            DbContext = dbContext;
            ConnectionIds = connectionIds;
            HubContext = hubContext;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectionIds.Remove(Context.ConnectionId);

            // TODO handle disconnect
            //LeaveRoom();
            //DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        //TODO not working
        public Task SignOut()
        {
            return Task.CompletedTask;
        }

        public Task SignIn(string username, string password)
        {
            // Checking if user exists and verifying
            User user = DbContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null || user.Password != password)
            {
                Clients.Client(Context.ConnectionId).SendAsync("Alert", "Invalid username or password");
                return null;
            }

            ConnectionIds.Add(Context.ConnectionId, user.Username);  // Adding to connectionIds list

            SendLobbyStatus();                                       // Sending Lobby status

            SendUserStatus(user);                                    // Sending User's status

            if (user.UserInGame != null)
            {
                SendRoomStatus(user.UserInGame.Room);                // Sending Room status
            }

            DbContext.SaveChanges();
            return Task.CompletedTask;
        }


        public Task JoinRoom(string roomId, int enterMoney)
        {
            // Getting the user, room, and players in room
            User user = GetUserByConnectionId();
            Room room = DbContext.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (user == null || room == null) 
                return null;                 // Verifying user and room exist 

            // Trying to add user to room
            if (!room.AddUser(DbContext, user, enterMoney))
            {
                Clients.Clients(GetUserConnections(user)).SendAsync("Alert", "Room is full!");
                return null;
            }

            SendRoomStatus(room);             // Sending everyone in the room the status

            SendLobbyStatus();                // Sending everyone in lobby status

            SendUserStatus(user);             // Sending User's status

            return Task.CompletedTask;
        }

        public Task LeaveRoom()
        {
            // Getting the user and room
            User user = GetUserByConnectionId();
            if (user == null || user.UserInGame == null)
                return null;                             // Verifying user and room exist

            Room room = user.UserInGame.Room;

            if(room.Stage != GameStage.Stopped)
                room.Fold(DbContext, user.UserInGame);       // Folding player

            // Returning player to lobby
            room.Users.Remove(user.UserInGame);
            user.Money += (int)user.UserInGame.MoneyInTable;

            if (room.Users.Count() > 1)
                room.StartGame(DbContext);

            DbContext.SaveChanges();

            // Sending everyone in the room the status
            List<User> playersInRoom = DbContext.Users.Where(u => u.UserInGame.Room.Id == room.Id).ToList();
            if (playersInRoom.Count() == 0)
            {
                DbContext.Rooms.Remove(room);
                DbContext.SaveChanges();
            }
            else
            {
                SendRoomStatus(room);
            }
            
            SendLobbyStatus();                // Sending everyone in lobby status

            SendUserStatus(user);             // Sending User's status

            return Task.CompletedTask;
        }

        public Task CreateRoom(string roomName, int enterMoney)
        {
            Room room = new Room() { Name = roomName };
            DbContext.Rooms.Add(room);
            DbContext.SaveChanges();
            JoinRoom(room.Id, enterMoney);
            CreateTurnTimer(room.Id);
            return Task.CompletedTask;
        }

        public Task SendMessage(string message)
        {
            // Getting the user and room
            User user = GetUserByConnectionId();
            if (user == null || user.UserInGame == null)
                return null;                             // Verifying user and room exist

            Room room = user.UserInGame.Room;

            //sending a message to all users in current room
            room.Users.ForEach(u=>
                Clients.Clients(GetUserConnections(u.User)).SendAsync("ReceiveMessage", user.Username, message)
            );
            return Task.CompletedTask;
        }

        // "Synchrnoenous" fold received from fold button
        public Task Fold()
        {
            // Getting the user and room
            User user = GetUserByConnectionId();
            if (user == null || user.UserInGame == null)
                return null;                             // Verifying user and room exist

            Room room = user.UserInGame.Room;

            resetTimer(room.Id);

            if (room.TalkingPosition != user.UserInGame.Position)
                return null;                  // Validating it's the player's turn

            room.Fold(DbContext, user.UserInGame);

            SendUserStatus(user);             // Sending User's status

            SendRoomStatus(room);             // Sending everyone in the room the status

            return Task.CompletedTask;
        }

        public Task Call()
        {
            // Getting the user and room
            User user = GetUserByConnectionId();
            if (user == null || user.UserInGame == null)
                return null;                             // Verifying user and room exist

            Room room = user.UserInGame.Room;

            resetTimer(room.Id);

            if (room.TalkingPosition != user.UserInGame.Position)
                return null;                  // Validating it's the player's turn

            room.Call(DbContext, user.UserInGame);

            SendUserStatus(user);             // Sending User's status

            SendRoomStatus(room);             // Sending everyone in the room the status

            return Task.CompletedTask;
        }

        public Task Raise(int amount)
        {
            // Getting the user and room
            User user = GetUserByConnectionId();
            if (user == null || user.UserInGame == null)
                return null;                  // Verifying user and room exist

            Room room = user.UserInGame.Room;

            resetTimer(room.Id);

            if (room.TalkingPosition != user.UserInGame.Position)
                return null;                  // Validating it's the player's turn

            room.Raise(DbContext, user.UserInGame, amount);

            SendUserStatus(user);             // Sending User's status

            SendRoomStatus(room);             // Sending everyone in the room the status

            return Task.CompletedTask;
        }

        public Task Check()
        {
            // Getting the user and room
            User user = GetUserByConnectionId();
            if (user == null || user.UserInGame == null)
                return null;                   // Verifying user and room exist

            Room room = user.UserInGame.Room;

            resetTimer(room.Id);

            if (room.TalkingPosition != user.UserInGame.Position)
                return null;                  // Validating it's the player's turn

            room.Check(DbContext, user.UserInGame);

            SendUserStatus(user);             // Sending User's status

            SendRoomStatus(room);             // Sending everyone in the room the status

            return Task.CompletedTask;
        }

        private void SendRoomStatus(Room room)
        {
            // Sending everyone in the room the status
            foreach (UserInGame u in room.Users)
            {
                List<string> tmpUserConnectionIds = GetUserConnections(u.User);
                Clients.Clients(tmpUserConnectionIds).SendAsync("RoomStatus", new RoomDto(room, u.User));
                SendUserStatus(u.User);
            }
        }

        private void SendUserStatus(User user)
        {
            List<string> userConnectionIds = GetUserConnections(user);
            HubContext.Clients.Clients(userConnectionIds).SendAsync("UserStatus", new UserDto(user));
        }

        private List<string> GetUserConnections(User user)
        {
            return ConnectionIds.Where(d => d.Value == user.Username).Select(d => d.Key).ToList();
        }

        private void SendLobbyStatus()
        {
            Clients.All.SendAsync("AllRoomsStatus", new LobbyDto(DbContext.Rooms.ToList()));
        }

        private User GetUserByConnectionId()
        {
            string username;
            if (!ConnectionIds.TryGetValue(Context.ConnectionId, out username))
            {
                return null;                 // Verifying room and user exist
            }
            return (DbContext.Users.FirstOrDefault(u => u.Username == username));
        }

        private System.Timers.Timer CreateTurnTimer(string roomId)
        {
            // TODO delete timer with room
            var timer = new System.Timers.Timer();
            timer.Interval = TimerInterval;
            timer.Elapsed += (sender, e) => TimerElapsed(sender, e, roomId);
            timer.Start();
            Timers.Add(roomId, timer);
            return timer;
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e, string roomId)
        {
            Room room = DbContext.Rooms.FirstOrDefault(r => r.Id == roomId);
            if (room.Stage != GameStage.Stopped)
            {
                UserInGame talkingUser = room.Users.Where(u => u.Position == room.TalkingPosition).FirstOrDefault();
                if (talkingUser == null)
                    return;

                room.Fold(DbContext, talkingUser);

                // Sending everyone in the room the status
                foreach (UserInGame u in room.Users)
                {
                    List<string> tmpUserConnectionIds = GetUserConnections(u.User);
                    HubContext.Clients.Clients(tmpUserConnectionIds).SendAsync("RoomStatus", new RoomDto(room, u.User));
                    SendUserStatus(u.User);
                }
            }
        }

        private void resetTimer(string roomId)
        {
            System.Timers.Timer timer;
            if (!Timers.TryGetValue(roomId, out timer))
            {
                return;                 // Verifying timer exist
            }
            timer.Stop();
            timer.Start();
        }
    }
}
