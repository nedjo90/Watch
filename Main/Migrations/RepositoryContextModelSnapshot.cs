﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace Main.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("DocumentId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DocumentTypeId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Entities.Models.DocumentStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("DocumentStatus");
                });

            modelBuilder.Entity("Entities.Models.DocumentType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("DocumentTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Label = "Carte d'identité",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UpdateDate = new DateTime(2024, 4, 25, 12, 6, 55, 135, DateTimeKind.Utc).AddTicks(1550)
                        },
                        new
                        {
                            Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Label = "Carte vitale",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UpdateDate = new DateTime(2024, 4, 25, 12, 6, 55, 135, DateTimeKind.Utc).AddTicks(1580)
                        },
                        new
                        {
                            Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            CreatedBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Label = "Carte bleu",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UpdateDate = new DateTime(2024, 4, 25, 12, 6, 55, 135, DateTimeKind.Utc).AddTicks(1590)
                        });
                });

            modelBuilder.Entity("Entities.Models.DocumentTypeXTrainingType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("DocumentTypeXTrainingTypeId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DocumentTypeId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("TrainingTypeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("TrainingTypeId");

                    b.ToTable("DocumentTypeXTrainingType");
                });

            modelBuilder.Entity("Entities.Models.DocumentXDocumentStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("DocumentXDocumentStatusId");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("DocumentStatusId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StatusDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("DocumentStatusId");

                    b.ToTable("DocumentXDocumentStatus");
                });

            modelBuilder.Entity("Entities.Models.LateMiss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("LateMissId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DeclarationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("LateMissTypeId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("LateMissTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("LateMisses");
                });

            modelBuilder.Entity("Entities.Models.LateMissDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("LateMissDocumentId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("LateMissId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("LateMissId");

                    b.ToTable("LateMissDocuments");
                });

            modelBuilder.Entity("Entities.Models.LateMissStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("LateMissStatus");
                });

            modelBuilder.Entity("Entities.Models.LateMissType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("LateMissTypeId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("LateMissTypes");
                });

            modelBuilder.Entity("Entities.Models.LateMissXLateMissStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("LateMissXLateMissStatusId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("LateMissId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("LateMissStatusId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("LateMissId");

                    b.HasIndex("LateMissStatusId");

                    b.ToTable("LateMissXLateMissStatus");
                });

            modelBuilder.Entity("Entities.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("NotificationId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("NotificationTypeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationTypeId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Entities.Models.NotificationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("NotificationTypes");
                });

            modelBuilder.Entity("Entities.Models.ProfessionalStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("ProfessionalStatus");
                });

            modelBuilder.Entity("Entities.Models.Training", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("TrainingId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("TrainingTypeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("TrainingTypeId");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("Entities.Models.TrainingType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TrainingTypes");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("UserId");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NativeCity")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("NativeCountry")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostCode")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("ProfessionalStatusId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ProfessionalStatusId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Models.UserXNotification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("UserXNotificationId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("NotificationId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserXNotification");
                });

            modelBuilder.Entity("Entities.Models.UserXTraining", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("UserXTrainingId");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("TrainingId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TrainingId");

                    b.HasIndex("UserId");

                    b.ToTable("UserXTraining");
                });

            modelBuilder.Entity("Entities.Models.Document", b =>
                {
                    b.HasOne("Entities.Models.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.DocumentTypeXTrainingType", b =>
                {
                    b.HasOne("Entities.Models.DocumentType", "DocumentType")
                        .WithMany("DocumentTypeXTrainingTypeCollection")
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.TrainingType", "TrainingType")
                        .WithMany("DocumentTypeXTrainingTypeCollection")
                        .HasForeignKey("TrainingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("TrainingType");
                });

            modelBuilder.Entity("Entities.Models.DocumentXDocumentStatus", b =>
                {
                    b.HasOne("Entities.Models.Document", "Document")
                        .WithMany("DocumentXDocumentStatusCollection")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.DocumentStatus", "DocumentStatus")
                        .WithMany("DocumentXDocumentStatusCollection")
                        .HasForeignKey("DocumentStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("DocumentStatus");
                });

            modelBuilder.Entity("Entities.Models.LateMiss", b =>
                {
                    b.HasOne("Entities.Models.LateMissType", "LateMissType")
                        .WithMany()
                        .HasForeignKey("LateMissTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LateMissType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.LateMissDocument", b =>
                {
                    b.HasOne("Entities.Models.LateMiss", "LateMiss")
                        .WithMany()
                        .HasForeignKey("LateMissId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LateMiss");
                });

            modelBuilder.Entity("Entities.Models.LateMissXLateMissStatus", b =>
                {
                    b.HasOne("Entities.Models.LateMiss", "LateMiss")
                        .WithMany("LateMissXLateMissStatusCollection")
                        .HasForeignKey("LateMissId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.LateMissStatus", "LateMissStatus")
                        .WithMany("LateMissXLateMissStatusCollection")
                        .HasForeignKey("LateMissStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LateMiss");

                    b.Navigation("LateMissStatus");
                });

            modelBuilder.Entity("Entities.Models.Notification", b =>
                {
                    b.HasOne("Entities.Models.NotificationType", "NotificationType")
                        .WithMany()
                        .HasForeignKey("NotificationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotificationType");
                });

            modelBuilder.Entity("Entities.Models.Training", b =>
                {
                    b.HasOne("Entities.Models.TrainingType", "TrainingType")
                        .WithMany()
                        .HasForeignKey("TrainingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainingType");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.HasOne("Entities.Models.ProfessionalStatus", "ProfessionalStatus")
                        .WithMany()
                        .HasForeignKey("ProfessionalStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfessionalStatus");
                });

            modelBuilder.Entity("Entities.Models.UserXNotification", b =>
                {
                    b.HasOne("Entities.Models.Notification", "Notification")
                        .WithMany("UserXNotificationCollection")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("UserXNotificationCollection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.UserXTraining", b =>
                {
                    b.HasOne("Entities.Models.Training", "Training")
                        .WithMany()
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.User", "User")
                        .WithMany("UserXTrainingCollection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Models.Document", b =>
                {
                    b.Navigation("DocumentXDocumentStatusCollection");
                });

            modelBuilder.Entity("Entities.Models.DocumentStatus", b =>
                {
                    b.Navigation("DocumentXDocumentStatusCollection");
                });

            modelBuilder.Entity("Entities.Models.DocumentType", b =>
                {
                    b.Navigation("DocumentTypeXTrainingTypeCollection");
                });

            modelBuilder.Entity("Entities.Models.LateMiss", b =>
                {
                    b.Navigation("LateMissXLateMissStatusCollection");
                });

            modelBuilder.Entity("Entities.Models.LateMissStatus", b =>
                {
                    b.Navigation("LateMissXLateMissStatusCollection");
                });

            modelBuilder.Entity("Entities.Models.Notification", b =>
                {
                    b.Navigation("UserXNotificationCollection");
                });

            modelBuilder.Entity("Entities.Models.TrainingType", b =>
                {
                    b.Navigation("DocumentTypeXTrainingTypeCollection");
                });

            modelBuilder.Entity("Entities.Models.User", b =>
                {
                    b.Navigation("UserXNotificationCollection");

                    b.Navigation("UserXTrainingCollection");
                });
#pragma warning restore 612, 618
        }
    }
}
