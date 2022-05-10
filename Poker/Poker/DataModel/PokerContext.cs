﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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

        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<UserInRoom> UserInRoom { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=AMITS-PC\\SQLEXPRESS;Initial Catalog=PokerNew;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).ValueGeneratedNever();

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserInRoom>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Room)
                    .WithMany()
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserInRoo__RoomI__412EB0B6");

                entity.HasOne(d => d.UserNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserInRoo__userN__403A8C7D");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.Property(e => e.UserName)
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