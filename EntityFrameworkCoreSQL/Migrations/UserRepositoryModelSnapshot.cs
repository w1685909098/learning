﻿// <auto-generated />
using System;
using EntityFrameworkCoreSQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCoreSQL.Migrations
{
    [DbContext(typeof(UserRepository))]
    partial class UserRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Register", b =>
                {
                    b.Property<string>("UserName")
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmailId")
                        .HasColumnType("int");

                    b.Property<int>("HelpBean")
                        .HasColumnType("int");

                    b.Property<int>("HelpCredit")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("InvitationCode")
                        .HasColumnType("int");

                    b.Property<string>("InvitedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VerificationCode")
                        .HasColumnType("int");

                    b.Property<int>("helpMoney")
                        .HasColumnType("int");

                    b.HasKey("UserName");

                    b.HasIndex("CreateTime");

                    b.HasIndex("EmailId")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("EntityFrameworkCoreSQL.Entities.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RegisterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("Entities.Register", b =>
                {
                    b.HasOne("EntityFrameworkCoreSQL.Entities.Email", "Email")
                        .WithOne("Register")
                        .HasForeignKey("Entities.Register", "EmailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
