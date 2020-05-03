﻿// <auto-generated />
using System;
using ForumService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ForumService.Data.Migrations
{
    [DbContext(typeof(ForumServiceContext))]
    [Migration("20191225222137_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ForumService.Data.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answear")
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Post");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Created")
                        .IsUnique()
                        .HasName("IX_Post_Created");

                    b.HasIndex("ThreadId")
                        .HasName("IX_Posts_ThreadId");

                    b.ToTable("Posts","Forum");
                });

            modelBuilder.Entity("ForumService.Data.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descriprion")
                        .IsRequired()
                        .HasColumnType("nvarchar(3000)")
                        .HasMaxLength(3000);

                    b.Property<int>("ThumbnailId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id")
                        .HasName("PK_Subject");

                    b.HasIndex("ThumbnailId")
                        .HasName("IX_Subjects_ThumbnailId");

                    b.HasIndex("Title")
                        .IsUnique()
                        .HasName("IX_Subject_SubjectName");

                    b.ToTable("Subjects","Forum");
                });

            modelBuilder.Entity("ForumService.Data.Entities.Thread", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(4000)")
                        .HasMaxLength(4000);

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id")
                        .HasName("PK_Thread");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Created")
                        .IsUnique()
                        .HasName("IX_Thread_Created");

                    b.HasIndex("SubjectId")
                        .HasName("IX_Thread_SubjectId");

                    b.ToTable("Threads","Forum");
                });

            modelBuilder.Entity("ForumService.Data.Entities.Thumbnail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasMaxLength(256000);

                    b.HasKey("Id")
                        .HasName("PK_Thumbnail");

                    b.ToTable("Thumbnails","Forum");
                });

            modelBuilder.Entity("ForumService.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users","Security");
                });

            modelBuilder.Entity("ForumService.Data.Entities.Post", b =>
                {
                    b.HasOne("ForumService.Data.Entities.User", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_Posts_Author")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("ForumService.Data.Entities.Thread", "Thread")
                        .WithMany("Post")
                        .HasForeignKey("ThreadId")
                        .HasConstraintName("FK_Posts_Thread")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForumService.Data.Entities.Subject", b =>
                {
                    b.HasOne("ForumService.Data.Entities.Thumbnail", "Thumbnail")
                        .WithMany("Subject")
                        .HasForeignKey("ThumbnailId")
                        .HasConstraintName("FK_Subjects_Thumbnails")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForumService.Data.Entities.Thread", b =>
                {
                    b.HasOne("ForumService.Data.Entities.User", "Author")
                        .WithMany("Threads")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_Thread_Author")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForumService.Data.Entities.Subject", "Subject")
                        .WithMany("Thread")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Thread_Subjects")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}