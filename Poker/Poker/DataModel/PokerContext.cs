﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Poker.DataModel;

#nullable disable

namespace PokerClassLibrary
{
    public partial class PokerContext : DbContext
    {
        public PokerContext()
        {
        }

        public PokerContext(DbContextOptions<PokerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Pot> Pots { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                //optionsBuilder.UseSqlServer("Data Source=AMITS-PC\\SQLEXPRESS;Initial Catalog=PokerNew;Integrated Security=True;Connect Timeout=30");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedOnAdd();

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(50);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserMoney).HasColumnName("userMoney");
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}