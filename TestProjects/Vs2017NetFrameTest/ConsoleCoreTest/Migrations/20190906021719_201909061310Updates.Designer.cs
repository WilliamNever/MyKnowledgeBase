﻿// <auto-generated />
using System;
using ConsoleCoreTest.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleCoreTest.Migrations
{
    [DbContext(typeof(DBCTXTContext))]
    [Migration("20190906021719_201909061310Updates")]
    partial class _201909061310Updates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleCoreTest.DBModels.Addresses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AddIdentity")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newsequentialid())");

                    b.Property<string>("Addr")
                        .HasColumnName("addr");

                    b.Property<string>("Email");

                    b.Property<string>("Phone")
                        .HasColumnName("phone");

                    b.Property<int>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IX_UserID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("ConsoleCoreTest.DBModels.UserInfors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<DateTime>("LoginDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(32);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasName("UserNameUniqueIndex");

                    b.ToTable("UserInfors");
                });

            modelBuilder.Entity("ConsoleCoreTest.DBModels.Addresses", b =>
                {
                    b.HasOne("ConsoleCoreTest.DBModels.UserInfors", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.Addresses_dbo.UserInfors_UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
