﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RusRoads.API.Migrations
{
    [DbContext(typeof(RusRoadsContext))]
    [Migration("20250216125323_UpdateEmployee")]
    partial class UpdateEmployee
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RusRoads.API.Entity.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateAdmission")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DirectedActivity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("File")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Applicant");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("DocumentId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("DocumentId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("HasComments")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateBorn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("HelperId")
                        .HasColumnType("integer");

                    b.Property<string>("JobNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int?>("LeaderId")
                        .HasColumnType("integer");

                    b.Property<int?>("MessuareId")
                        .HasColumnType("integer");

                    b.Property<string>("PersonalPhone")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubdivisionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HelperId");

                    b.HasIndex("LeaderId");

                    b.HasIndex("MessuareId");

                    b.HasIndex("SubdivisionId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicantId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("RusRoads.API.Entity.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateApproval")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Material");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Messuare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("MaterialId")
                        .HasColumnType("integer");

                    b.Property<int>("MessuareTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ResponsiblePerson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("MessuareTypeId");

                    b.ToTable("Messuare");
                });

            modelBuilder.Entity("RusRoads.API.Entity.MessuareType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MessuareType");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Subdivision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("LeaderSubdivisionId")
                        .HasColumnType("integer");

                    b.Property<int?>("MessuareId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LeaderSubdivisionId");

                    b.HasIndex("MessuareId");

                    b.ToTable("Subdivision");
                });

            modelBuilder.Entity("RusRoads.API.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Comment", b =>
                {
                    b.HasOne("RusRoads.API.Entity.Employee", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RusRoads.API.Entity.Document", "Document")
                        .WithMany("Comments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Document");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Employee", b =>
                {
                    b.HasOne("RusRoads.API.Entity.Employee", "Helper")
                        .WithMany()
                        .HasForeignKey("HelperId");

                    b.HasOne("RusRoads.API.Entity.Employee", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId");

                    b.HasOne("RusRoads.API.Entity.Messuare", "Messuare")
                        .WithMany("Employees")
                        .HasForeignKey("MessuareId");

                    b.HasOne("RusRoads.API.Entity.Subdivision", "Subdivision")
                        .WithMany("Employees")
                        .HasForeignKey("SubdivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Helper");

                    b.Navigation("Leader");

                    b.Navigation("Messuare");

                    b.Navigation("Subdivision");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Event", b =>
                {
                    b.HasOne("RusRoads.API.Entity.Applicant", "Applicant")
                        .WithMany("Events")
                        .HasForeignKey("ApplicantId");

                    b.HasOne("RusRoads.API.Entity.Employee", "Employee")
                        .WithMany("Events")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RusRoads.API.Entity.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("Employee");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Material", b =>
                {
                    b.HasOne("RusRoads.API.Entity.Employee", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Messuare", b =>
                {
                    b.HasOne("RusRoads.API.Entity.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("RusRoads.API.Entity.MessuareType", "MessuareType")
                        .WithMany("Messuares")
                        .HasForeignKey("MessuareTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("MessuareType");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Subdivision", b =>
                {
                    b.HasOne("RusRoads.API.Entity.Subdivision", "LeaderSubdivision")
                        .WithMany()
                        .HasForeignKey("LeaderSubdivisionId");

                    b.HasOne("RusRoads.API.Entity.Messuare", "Messuare")
                        .WithMany("Subdivisions")
                        .HasForeignKey("MessuareId");

                    b.Navigation("LeaderSubdivision");

                    b.Navigation("Messuare");
                });

            modelBuilder.Entity("RusRoads.API.Entity.User", b =>
                {
                    b.HasOne("RusRoads.API.Entity.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Applicant", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Document", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Employee", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("RusRoads.API.Entity.EventType", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Messuare", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Subdivisions");
                });

            modelBuilder.Entity("RusRoads.API.Entity.MessuareType", b =>
                {
                    b.Navigation("Messuares");
                });

            modelBuilder.Entity("RusRoads.API.Entity.Subdivision", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
