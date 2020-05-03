﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TokenService.Data;

namespace TokenService.Data.Migrations
{
    [DbContext(typeof(TokenServiceContext))]
    partial class TokenServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TokenService.Data.Entities.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Name")
                        .HasName("PK_Roles");

                    b.ToTable("Roles","Security");

                    b.HasAnnotation("READONLY_ANNOTATION", true);

                    b.HasData(
                        new
                        {
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("TokenService.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("SecurityStamp")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("PK_Users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("IX_Users_Email");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasName("IX_Users_Username");

                    b.ToTable("Users","Security");
                });

            modelBuilder.Entity("TokenService.Data.Entities.UserRole", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("RoleId")
                        .HasName("IX_UserRoles_RoleId");

                    b.HasIndex("UserId")
                        .HasName("IX_UserRoles_UserId");

                    b.ToTable("UserRoles","Security");
                });

            modelBuilder.Entity("TokenService.Data.Entities.UserRole", b =>
                {
                    b.HasOne("TokenService.Data.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRoles_Roles")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TokenService.Data.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRoles_Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}