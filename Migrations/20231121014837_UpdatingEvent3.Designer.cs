﻿// <auto-generated />
using BECapstone;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BECapstone.Migrations
{
    [DbContext(typeof(BEDbContext))]
    [Migration("20231121014837_UpdatingEvent3")]
    partial class UpdatingEvent3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BECapstone.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Class");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fighter"
                        });
                });

            modelBuilder.Entity("BECapstone.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EndTimeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PlayTypeId")
                        .HasColumnType("integer");

                    b.Property<int>("StartTimeId")
                        .HasColumnType("integer");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EndTimeId");

                    b.HasIndex("PlayTypeId");

                    b.HasIndex("StartTimeId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTimeId = 13,
                            Name = "Cole's Event",
                            PlayTypeId = 1,
                            StartTimeId = 2,
                            uid = ""
                        });
                });

            modelBuilder.Entity("BECapstone.Models.PlayType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PlayTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Good"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Evil"
                        });
                });

            modelBuilder.Entity("BECapstone.Models.TimeSlots", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TimeSlots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "1:00 AM"
                        },
                        new
                        {
                            Id = 13,
                            Value = "1:00 PM"
                        },
                        new
                        {
                            Id = 2,
                            Value = "2:00 AM"
                        },
                        new
                        {
                            Id = 14,
                            Value = "2:00 PM"
                        },
                        new
                        {
                            Id = 3,
                            Value = "3:00 AM"
                        },
                        new
                        {
                            Id = 15,
                            Value = "3:00 PM"
                        },
                        new
                        {
                            Id = 4,
                            Value = "4:00 AM"
                        },
                        new
                        {
                            Id = 16,
                            Value = "4:00 PM"
                        },
                        new
                        {
                            Id = 5,
                            Value = "5:00 AM"
                        },
                        new
                        {
                            Id = 17,
                            Value = "5:00 PM"
                        },
                        new
                        {
                            Id = 6,
                            Value = "6:00 AM"
                        },
                        new
                        {
                            Id = 18,
                            Value = "6:00 PM"
                        },
                        new
                        {
                            Id = 7,
                            Value = "7:00 AM"
                        },
                        new
                        {
                            Id = 19,
                            Value = "7:00 PM"
                        },
                        new
                        {
                            Id = 8,
                            Value = "8:00 AM"
                        },
                        new
                        {
                            Id = 20,
                            Value = "8:00 PM"
                        },
                        new
                        {
                            Id = 9,
                            Value = "9:00 AM"
                        },
                        new
                        {
                            Id = 21,
                            Value = "9:00 PM"
                        },
                        new
                        {
                            Id = 10,
                            Value = "10:00 AM"
                        },
                        new
                        {
                            Id = 22,
                            Value = "10:00 PM"
                        },
                        new
                        {
                            Id = 11,
                            Value = "11:00 AM"
                        },
                        new
                        {
                            Id = 23,
                            Value = "11:00 PM"
                        },
                        new
                        {
                            Id = 12,
                            Value = "12:00 AM"
                        },
                        new
                        {
                            Id = 24,
                            Value = "12:00 PM"
                        });
                });

            modelBuilder.Entity("BECapstone.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "cole.ama@gmail.com",
                            Name = "Cole",
                            uid = ""
                        });
                });

            modelBuilder.Entity("ClassEvents", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("EventsId")
                        .HasColumnType("integer");

                    b.HasKey("ClassId", "EventsId");

                    b.HasIndex("EventsId");

                    b.ToTable("ClassEvents");
                });

            modelBuilder.Entity("ClassUser", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("ClassId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ClassUser");
                });

            modelBuilder.Entity("EventsUser", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("integer");

                    b.Property<int>("UsersId")
                        .HasColumnType("integer");

                    b.HasKey("EventsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("EventsUser");
                });

            modelBuilder.Entity("BECapstone.Models.Events", b =>
                {
                    b.HasOne("BECapstone.Models.TimeSlots", "EndTime")
                        .WithMany()
                        .HasForeignKey("EndTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BECapstone.Models.PlayType", "PlayType")
                        .WithMany()
                        .HasForeignKey("PlayTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BECapstone.Models.TimeSlots", "StartTime")
                        .WithMany()
                        .HasForeignKey("StartTimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EndTime");

                    b.Navigation("PlayType");

                    b.Navigation("StartTime");
                });

            modelBuilder.Entity("ClassEvents", b =>
                {
                    b.HasOne("BECapstone.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BECapstone.Models.Events", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClassUser", b =>
                {
                    b.HasOne("BECapstone.Models.Class", null)
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BECapstone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventsUser", b =>
                {
                    b.HasOne("BECapstone.Models.Events", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BECapstone.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
