﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PokerClassLibrary;

namespace Poker.Migrations
{
    [DbContext(typeof(PokerContext))]
    [Migration("20220510143642_AddLobbyDto")]
    partial class AddLobbyDto
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Hebrew_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Poker.DataModel.Pot", b =>
                {
                    b.Property<int>("PotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Money")
                        .HasColumnType("float");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("PotId");

                    b.HasIndex("RoomId");

                    b.ToTable("Pots");
                });

            modelBuilder.Entity("PokerClassLibrary.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("RoomId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PokerClassLibrary.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("DealerPosition")
                        .HasColumnType("int");

                    b.Property<int?>("Pot")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TalkingPosition")
                        .HasColumnType("int");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("PokerClassLibrary.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("UserMoney")
                        .HasColumnType("float")
                        .HasColumnName("userMoney");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PokerClassLibrary.UserInRoom", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("userName");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("isActive");

                    b.Property<int?>("MoneyInTable")
                        .HasColumnType("int");

                    b.Property<short?>("Position")
                        .HasColumnType("smallint")
                        .HasColumnName("position");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Username");

                    b.HasIndex("RoomId");

                    b.ToTable("UsersInRoom");
                });

            modelBuilder.Entity("Poker.DataModel.Pot", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("Pots")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("PokerClassLibrary.Card", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("Deck")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("PokerClassLibrary.UserInRoom", b =>
                {
                    b.HasOne("PokerClassLibrary.Room", null)
                        .WithMany("Players")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PokerClassLibrary.User", "UsernameNavigation")
                        .WithMany()
                        .HasForeignKey("Username")
                        .HasConstraintName("FK__UserInRoo__userN__403A8C7D")
                        .IsRequired();

                    b.Navigation("UsernameNavigation");
                });

            modelBuilder.Entity("PokerClassLibrary.Room", b =>
                {
                    b.Navigation("Deck");

                    b.Navigation("Players");

                    b.Navigation("Pots");
                });
#pragma warning restore 612, 618
        }
    }
}
