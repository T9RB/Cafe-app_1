﻿// <auto-generated />
using System;
using Cafe.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cafe.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241205175423_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Cafe.Core.Models.Dish", b =>
                {
                    b.Property<int>("IdDish")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("IdDish")
                        .HasName("Dishes_pk");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Cafe.Core.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountClient")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("TypePayment")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("IdOrder")
                        .HasName("Orders_pk");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Cafe.Core.Models.OrderDish", b =>
                {
                    b.Property<int>("IdList")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdDish")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdList")
                        .HasName("OrderDish_pk");

                    b.HasIndex("IdDish");

                    b.HasIndex("IdOrder");

                    b.ToTable("OrderDish", (string)null);
                });

            modelBuilder.Entity("Cafe.Core.Models.Post", b =>
                {
                    b.Property<int>("IdPost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("IdPost")
                        .HasName("Posts_pk");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Cafe.Core.Models.StatusesUser", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("IdStatus")
                        .HasName("StatusesUser_pk");

                    b.ToTable("StatusesUser", (string)null);
                });

            modelBuilder.Entity("Cafe.Core.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmplContract")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Fname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("FName");

                    b.Property<int>("IdPost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("LName");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sname")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("SName");

                    b.HasKey("IdUser")
                        .HasName("Users_pk");

                    b.HasIndex("IdPost");

                    b.HasIndex("IdStatus");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Cafe.Core.Models.UserShift", b =>
                {
                    b.Property<int>("IdList")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdShift")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("IdList")
                        .HasName("UserShift_pk");

                    b.HasIndex("IdShift");

                    b.HasIndex("IdUser");

                    b.ToTable("UserShift", (string)null);
                });

            modelBuilder.Entity("Cafe.Core.Models.UsersOrder", b =>
                {
                    b.Property<int>("IdList")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdOrder")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdList")
                        .HasName("UsersOrders_pk");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdUser");

                    b.ToTable("UsersOrders");
                });

            modelBuilder.Entity("Cafe.Core.Models.WorkShift", b =>
                {
                    b.Property<int>("IdShift")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("IdShift")
                        .HasName("WorkShifts_pk");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("Cafe.Core.Models.OrderDish", b =>
                {
                    b.HasOne("Cafe.Core.Models.Dish", "IdDishNavigation")
                        .WithMany("OrderDishes")
                        .HasForeignKey("IdDish")
                        .IsRequired()
                        .HasConstraintName("OrderDish_Dishes_IdDish_fk");

                    b.HasOne("Cafe.Core.Models.Order", "IdOrderNavigation")
                        .WithMany("OrderDishes")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("OrderDish_Orders_IdOrder_fk");

                    b.Navigation("IdDishNavigation");

                    b.Navigation("IdOrderNavigation");
                });

            modelBuilder.Entity("Cafe.Core.Models.User", b =>
                {
                    b.HasOne("Cafe.Core.Models.Post", "IdPostNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdPost")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("Users_Posts_IdPost_fk");

                    b.HasOne("Cafe.Core.Models.StatusesUser", "IdStatusNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Users_StatusesUser_IdStatus_fk");

                    b.Navigation("IdPostNavigation");

                    b.Navigation("IdStatusNavigation");
                });

            modelBuilder.Entity("Cafe.Core.Models.UserShift", b =>
                {
                    b.HasOne("Cafe.Core.Models.WorkShift", "IdShiftNavigation")
                        .WithMany("UserShifts")
                        .HasForeignKey("IdShift")
                        .IsRequired()
                        .HasConstraintName("UserShift_WorkShifts_IdShift_fk");

                    b.HasOne("Cafe.Core.Models.User", "IdUserNavigation")
                        .WithMany("UserShifts")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("UserShift_Users_IdUser_fk");

                    b.Navigation("IdShiftNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Cafe.Core.Models.UsersOrder", b =>
                {
                    b.HasOne("Cafe.Core.Models.Order", "IdOrderNavigation")
                        .WithMany("UsersOrders")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("UsersOrders_Orders_IdOrder_fk");

                    b.HasOne("Cafe.Core.Models.User", "IdUserNavigation")
                        .WithMany("UsersOrders")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("UsersOrders_Users_IdUser_fk");

                    b.Navigation("IdOrderNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Cafe.Core.Models.Dish", b =>
                {
                    b.Navigation("OrderDishes");
                });

            modelBuilder.Entity("Cafe.Core.Models.Order", b =>
                {
                    b.Navigation("OrderDishes");

                    b.Navigation("UsersOrders");
                });

            modelBuilder.Entity("Cafe.Core.Models.Post", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Cafe.Core.Models.StatusesUser", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Cafe.Core.Models.User", b =>
                {
                    b.Navigation("UserShifts");

                    b.Navigation("UsersOrders");
                });

            modelBuilder.Entity("Cafe.Core.Models.WorkShift", b =>
                {
                    b.Navigation("UserShifts");
                });
#pragma warning restore 612, 618
        }
    }
}