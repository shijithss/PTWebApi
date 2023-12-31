﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using User.Microservice.Infrastructure.Data;

#nullable disable

namespace User.Microservice.Infrastructure.Migrations.QueryDB
{
    [DbContext(typeof(ApplicationQueryDBContext))]
    [Migration("20230808204156_InitialQuery")]
    partial class InitialQuery
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("User.Microservice.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("city")
                        .HasColumnType("text");

                    b.Property<string>("postalCode")
                        .HasColumnType("text");

                    b.Property<string>("state")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.PostQuery", b =>
                {
                    b.Property<int>("postid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("postid"));

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("UserQueryuserid")
                        .HasColumnType("integer");

                    b.Property<string>("body")
                        .HasColumnType("text");

                    b.Property<bool>("hasFictionTag")
                        .HasColumnType("boolean");

                    b.Property<bool>("hasFrenchTag")
                        .HasColumnType("boolean");

                    b.Property<bool>("hasMorethanTwoReactions")
                        .HasColumnType("boolean");

                    b.Property<int>("reactions")
                        .HasColumnType("integer");

                    b.Property<List<string>>("tags")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("postid");

                    b.HasIndex("UserQueryuserid");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.Todo", b =>
                {
                    b.Property<int>("todoid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("todoid"));

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("UserQueryuserid")
                        .HasColumnType("integer");

                    b.Property<bool>("completed")
                        .HasColumnType("boolean");

                    b.Property<string>("todo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("todoid");

                    b.HasIndex("UserQueryuserid");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.UserQuery", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("userid"));

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("addressId")
                        .HasColumnType("integer");

                    b.Property<int>("age")
                        .HasColumnType("integer");

                    b.Property<string>("birthDate")
                        .HasColumnType("text");

                    b.Property<string>("bloodGroup")
                        .HasColumnType("text");

                    b.Property<string>("domain")
                        .HasColumnType("text");

                    b.Property<string>("ein")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("eyeColor")
                        .HasColumnType("text");

                    b.Property<string>("firstName")
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .HasColumnType("text");

                    b.Property<int>("height")
                        .HasColumnType("integer");

                    b.Property<string>("image")
                        .HasColumnType("text");

                    b.Property<string>("ip")
                        .HasColumnType("text");

                    b.Property<string>("lastName")
                        .HasColumnType("text");

                    b.Property<string>("macAddress")
                        .HasColumnType("text");

                    b.Property<string>("maidenName")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .HasColumnType("text");

                    b.Property<string>("ssn")
                        .HasColumnType("text");

                    b.Property<string>("university")
                        .HasColumnType("text");

                    b.Property<string>("userAgent")
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.Property<double>("weight")
                        .HasColumnType("double precision");

                    b.HasKey("userid");

                    b.HasIndex("addressId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.Address", b =>
                {
                    b.OwnsOne("User.Microservice.Domain.Entities.Coordinates", "coordinates", b1 =>
                        {
                            b1.Property<int>("AddressId")
                                .HasColumnType("integer");

                            b1.Property<double>("lat")
                                .HasColumnType("double precision");

                            b1.Property<double>("lng")
                                .HasColumnType("double precision");

                            b1.HasKey("AddressId");

                            b1.ToTable("Address");

                            b1.WithOwner()
                                .HasForeignKey("AddressId");
                        });

                    b.Navigation("coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.PostQuery", b =>
                {
                    b.HasOne("User.Microservice.Domain.Entities.UserQuery", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserQueryuserid");
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.Todo", b =>
                {
                    b.HasOne("User.Microservice.Domain.Entities.UserQuery", null)
                        .WithMany("Todos")
                        .HasForeignKey("UserQueryuserid");
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.UserQuery", b =>
                {
                    b.HasOne("User.Microservice.Domain.Entities.Address", "address")
                        .WithMany()
                        .HasForeignKey("addressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("User.Microservice.Domain.Entities.Bank", "bank", b1 =>
                        {
                            b1.Property<int>("UserQueryuserid")
                                .HasColumnType("integer");

                            b1.Property<string>("cardExpire")
                                .HasColumnType("text");

                            b1.Property<string>("cardNumber")
                                .HasColumnType("text");

                            b1.Property<string>("cardType")
                                .HasColumnType("text");

                            b1.Property<string>("currency")
                                .HasColumnType("text");

                            b1.Property<string>("iban")
                                .HasColumnType("text");

                            b1.HasKey("UserQueryuserid");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserQueryuserid");
                        });

                    b.OwnsOne("User.Microservice.Domain.Entities.Company", "company", b1 =>
                        {
                            b1.Property<int>("UserQueryuserid")
                                .HasColumnType("integer");

                            b1.Property<int>("addressId")
                                .HasColumnType("integer");

                            b1.Property<string>("department")
                                .HasColumnType("text");

                            b1.Property<string>("name")
                                .HasColumnType("text");

                            b1.Property<string>("title")
                                .HasColumnType("text");

                            b1.HasKey("UserQueryuserid");

                            b1.HasIndex("addressId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserQueryuserid");

                            b1.HasOne("User.Microservice.Domain.Entities.Address", "address")
                                .WithMany()
                                .HasForeignKey("addressId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("address");
                        });

                    b.OwnsOne("User.Microservice.Domain.Entities.Hair", "hair", b1 =>
                        {
                            b1.Property<int>("UserQueryuserid")
                                .HasColumnType("integer");

                            b1.Property<string>("color")
                                .HasColumnType("text");

                            b1.Property<string>("type")
                                .HasColumnType("text");

                            b1.HasKey("UserQueryuserid");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserQueryuserid");
                        });

                    b.Navigation("address");

                    b.Navigation("bank")
                        .IsRequired();

                    b.Navigation("company")
                        .IsRequired();

                    b.Navigation("hair")
                        .IsRequired();
                });

            modelBuilder.Entity("User.Microservice.Domain.Entities.UserQuery", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
