﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrisonManagementSystem.Config;

namespace PrisonManagementSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Block", b =>
                {
                    b.Property<int>("BlockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BlockName")
                        .HasColumnType("text");

                    b.Property<int>("CareTakerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Facilities")
                        .HasColumnType("text");

                    b.Property<string>("GenderType")
                        .HasColumnType("text");

                    b.HasKey("BlockId");

                    b.HasIndex("CareTakerId");

                    b.ToTable("Block");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.CareTaker", b =>
                {
                    b.Property<int>("CareTakerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("CareTakerName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("CareTakerId");

                    b.ToTable("CareTaker");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Cell", b =>
                {
                    b.Property<int>("CellId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CellName")
                        .HasColumnType("text");

                    b.Property<string>("RenovationIssue")
                        .HasColumnType("text");

                    b.Property<bool>("isOccupied")
                        .HasColumnType("boolean");

                    b.HasKey("CellId");

                    b.ToTable("Cell");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Duty", b =>
                {
                    b.Property<int>("DutyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("DutyName")
                        .HasColumnType("text");

                    b.Property<int>("DutyTypeId")
                        .HasColumnType("integer");

                    b.HasKey("DutyId");

                    b.HasIndex("DutyTypeId");

                    b.ToTable("Duty");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.DutyType", b =>
                {
                    b.Property<int>("DutyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("DutyTypeId");

                    b.ToTable("DutyType");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Officer", b =>
                {
                    b.Property<int>("OfficerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("RankId")
                        .HasColumnType("integer");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("text");

                    b.HasKey("OfficerId");

                    b.HasIndex("RankId");

                    b.ToTable("Officer");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.OfficerDuty", b =>
                {
                    b.Property<int>("DutyId")
                        .HasColumnType("integer");

                    b.Property<int>("OfficerId")
                        .HasColumnType("integer");

                    b.HasKey("DutyId", "OfficerId");

                    b.HasIndex("OfficerId");

                    b.ToTable("OfficerDuty");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.OfficerRank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("RankId");

                    b.ToTable("OfficerRank");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Prisoner", b =>
                {
                    b.Property<int>("PrisonerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<int>("CellId")
                        .HasColumnType("integer");

                    b.Property<string>("ColorOfEye")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateConvicted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("EmergencyContact")
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpectedJailTerm")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("HealthConditions")
                        .HasColumnType("text");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Offence")
                        .HasColumnType("text");

                    b.Property<string>("OtherName")
                        .HasColumnType("text");

                    b.Property<string>("PassportURL")
                        .HasColumnType("text");

                    b.Property<int>("PrisonerClassificationId")
                        .HasColumnType("integer");

                    b.Property<string>("Sentence")
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("PrisonerId");

                    b.HasIndex("CellId");

                    b.HasIndex("PrisonerClassificationId");

                    b.ToTable("Prisoner");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.PrisonerClassification", b =>
                {
                    b.Property<int>("PrisonerClassificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Classification")
                        .HasColumnType("text");

                    b.HasKey("PrisonerClassificationId");

                    b.ToTable("PrisonerClassification");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.RemandStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("CaseStatement")
                        .HasColumnType("text");

                    b.Property<DateTime>("NextScheduledCourtDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PrisonerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PrisonerId");

                    b.ToTable("RemandStatus");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Visiting", b =>
                {
                    b.Property<int>("VisitingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DepartedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("VisitorId")
                        .HasColumnType("integer");

                    b.HasKey("VisitingId");

                    b.HasIndex("VisitorId");

                    b.ToTable("Visiting");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.VisitorForm", b =>
                {
                    b.Property<int>("VisitorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("PrisonerId")
                        .HasColumnType("integer");

                    b.Property<string>("ResidentAddress")
                        .HasColumnType("text");

                    b.HasKey("VisitorId");

                    b.HasIndex("PrisonerId");

                    b.ToTable("Visitor");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Block", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.CareTaker", "CareTaker")
                        .WithMany("Block")
                        .HasForeignKey("CareTakerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CareTaker");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Duty", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.DutyType", "DutyType")
                        .WithMany("Duty")
                        .HasForeignKey("DutyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DutyType");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Officer", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.OfficerRank", "Rank")
                        .WithMany("Officers")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rank");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.OfficerDuty", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.Duty", "Duty")
                        .WithMany("OfficerDuties")
                        .HasForeignKey("DutyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrisonManagementSystem.Db_Models.Officer", "Officer")
                        .WithMany("OfficerDuties")
                        .HasForeignKey("OfficerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Duty");

                    b.Navigation("Officer");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Prisoner", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.Cell", "Cell")
                        .WithMany("Prisoners")
                        .HasForeignKey("CellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrisonManagementSystem.Db_Models.PrisonerClassification", "PrisonerClassification")
                        .WithMany("Prisoners")
                        .HasForeignKey("PrisonerClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cell");

                    b.Navigation("PrisonerClassification");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.RemandStatus", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.Prisoner", "Prisoner")
                        .WithMany("RemandStatuses")
                        .HasForeignKey("PrisonerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prisoner");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Visiting", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.VisitorForm", "Visitor")
                        .WithMany("Visitings")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.VisitorForm", b =>
                {
                    b.HasOne("PrisonManagementSystem.Db_Models.Prisoner", "Prisoner")
                        .WithMany("Visitors")
                        .HasForeignKey("PrisonerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prisoner");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.CareTaker", b =>
                {
                    b.Navigation("Block");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Cell", b =>
                {
                    b.Navigation("Prisoners");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Duty", b =>
                {
                    b.Navigation("OfficerDuties");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.DutyType", b =>
                {
                    b.Navigation("Duty");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Officer", b =>
                {
                    b.Navigation("OfficerDuties");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.OfficerRank", b =>
                {
                    b.Navigation("Officers");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.Prisoner", b =>
                {
                    b.Navigation("RemandStatuses");

                    b.Navigation("Visitors");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.PrisonerClassification", b =>
                {
                    b.Navigation("Prisoners");
                });

            modelBuilder.Entity("PrisonManagementSystem.Db_Models.VisitorForm", b =>
                {
                    b.Navigation("Visitings");
                });
#pragma warning restore 612, 618
        }
    }
}
