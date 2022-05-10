﻿using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Collections.Generic;
using Poker;
using System.Linq;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using PokerClassLibrary;
using System.Diagnostics;
using Poker.DataModel.Dto;

namespace Poker.Hubs
{
    public class PokerHub : Hub
    {
        private readonly string _botUser;
        //private readonly IDictionary<string, UserConnection> _connections;
        PokerContext db = new PokerContext();// Connect to DB
                                             //private SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=Poker;Integrated Security=True");

        //public PokerHub(IDictionary<string, UserConnection> connections)
        //{
        //    _botUser = "notification";   //notification user name          
        //    _connections = connections; // all connections
        //}

        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
        //    {
        //        //removing connection
        //        _connections.Remove(Context.ConnectionId);

        //        //messaging user's group
        //        Clients.Group(userConnection.Room).SendAsync(
        //            "ReceiveMessage", _botUser, $"{userConnection.User} has left");

        //        //signaling user's group
        //        SendUsersConnected(userConnection.Room);
        //    }
        //    return base.OnDisconnectedAsync(exception);
        //}

        //TODO not working
        public Task SignOut()
        {
            Context.Abort();
            return Task.CompletedTask;
        }

        public async Task SignIn(string Username, string Password)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == Username);
            if (user == null || user.Password != Password)
            {
                await Clients.Client(Context.ConnectionId).SendAsync("SignInStatus", false,null);
                return;
            }

            user.ConnectionId = Context.ConnectionId;
            LobbyDto lobby = new LobbyDto(user,db.Rooms.ToList());
            await Clients.Client(Context.ConnectionId).SendAsync("SignInStatus",true,lobby);
        }


        public async Task JoinRoom(int RoomId)
        {

        }
        public async Task CreateRoom(int RoomId,string RoomName)
        {

        }

        //public async Task JoinRoom(string room)
        //{
        //    //storing old room to update
        //    string old_room = _connections[Context.ConnectionId].Room;
            
        //    //if clicked new room 
        //    if (room == "new")
        //        room = _connections[Context.ConnectionId].User + "'s Room";

        //    //updating groups
        //    _connections[Context.ConnectionId].Room = room;
        //    await Groups.AddToGroupAsync(Context.ConnectionId, room);
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, old_room);

        //    //sending join message
        //    await Clients.Group(room)
        //        .SendAsync(
        //        "ReceiveMessage", _botUser, $"{_connections[Context.ConnectionId].User} " +
        //        $"has joined {_connections[Context.ConnectionId].Room}"
        //        );

        //    //updating old room and new room
        //    await SendUsersConnected(old_room);
        //    await SendUsersConnected(_connections[Context.ConnectionId].Room);

        //    //updating rooms available
        //    await SendRoomsAvailable();
        //}

        //public async Task SendMessage(string message)
        //{
        //    //sending a message to all users in current room
        //    if (_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
        //    {
        //        await Clients.Group(userConnection.Room).SendAsync("ReceiveMessage", userConnection.User, message);
        //    }
        //}

        //public Task SendUsersConnected(string room)
        //{
        //    //getting all room users
        //    var users = _connections.Values.Where(c => c.Room == room).Select(c => c.User);

        //    //sending the user his current room
        //    Clients.Group(room).SendAsync("ReceivePage", room);
            
        //    //updating all players in the room
        //    return Clients.Group(room).SendAsync("UsersInRoom", users);
        //}
        //public Task SendRoomsAvailable()
        //{
        //    //filtering to get all Distinct rooms excluding Lobby
        //    var users = _connections.Values;

        //    List<String> list = new List<String>();
        //    for (int i = 0; i < users.Count(); i++)
        //        list.Add(users.ElementAt(i).Room);

        //    list = list.Distinct().Where(x => x != "Lobby").ToList();

        //    //updating Lobby rooms
        //    return Clients.Group("Lobby").SendAsync("ReceiveRooms", list);
        //}
    }
}
