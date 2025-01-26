﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SkillQuest_backend.Data;

#nullable disable

namespace SkillQuest_backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SkillQuest_backend.Models.Challenge", b =>
                {
                    b.Property<int>("ChallengeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChallengeId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PointsReward")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("ChallengeId");

                    b.HasIndex("CourseId");

                    b.ToTable("challenges");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("CourseId");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LessonId"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DurationMinutes")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("LessonId");

                    b.HasIndex("CourseId");

                    b.ToTable("lessons");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Reward", b =>
                {
                    b.Property<int>("RewardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RewardId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PointsRequired")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("RewardId");

                    b.ToTable("rewards");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RoleId"));

                    b.Property<int>("RoleName")
                        .HasColumnType("integer");

                    b.HasKey("RoleId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserChallenge", b =>
                {
                    b.Property<int>("UserChallengeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserChallengeId"));

                    b.Property<int>("ChallengeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserChallengeId");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("UserId");

                    b.ToTable("user_challenges");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserPoints", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId");

                    b.ToTable("user_points");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserProgress", b =>
                {
                    b.Property<int>("ProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProgressId"));

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LessonId")
                        .HasColumnType("integer");

                    b.Property<int?>("Score")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ProgressId");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("user_progress");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserReward", b =>
                {
                    b.Property<int>("UserRewardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserRewardId"));

                    b.Property<DateTime?>("AcquiredAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RewardId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("UserRewardId");

                    b.HasIndex("RewardId");

                    b.HasIndex("UserId");

                    b.ToTable("user_rewards");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Challenge", b =>
                {
                    b.HasOne("SkillQuest_backend.Models.Course", "Course")
                        .WithMany("Challenges")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Lesson", b =>
                {
                    b.HasOne("SkillQuest_backend.Models.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserChallenge", b =>
                {
                    b.HasOne("SkillQuest_backend.Models.Challenge", "Challenge")
                        .WithMany("UserChallenges")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillQuest_backend.Models.User", "User")
                        .WithMany("UserChallenges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Challenge");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserPoints", b =>
                {
                    b.HasOne("SkillQuest_backend.Models.User", "User")
                        .WithOne("UserPoints")
                        .HasForeignKey("SkillQuest_backend.Models.UserPoints", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserProgress", b =>
                {
                    b.HasOne("SkillQuest_backend.Models.Lesson", "Lesson")
                        .WithMany("UserProgress")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillQuest_backend.Models.User", "User")
                        .WithMany("UserProgress")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserReward", b =>
                {
                    b.HasOne("SkillQuest_backend.Models.Reward", "Reward")
                        .WithMany("UserRewards")
                        .HasForeignKey("RewardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillQuest_backend.Models.User", "User")
                        .WithMany("UserRewards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reward");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.UserRole", b =>
                {
                    b.HasOne("SkillQuest_backend.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillQuest_backend.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Challenge", b =>
                {
                    b.Navigation("UserChallenges");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Course", b =>
                {
                    b.Navigation("Challenges");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Lesson", b =>
                {
                    b.Navigation("UserProgress");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Reward", b =>
                {
                    b.Navigation("UserRewards");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("SkillQuest_backend.Models.User", b =>
                {
                    b.Navigation("UserChallenges");

                    b.Navigation("UserPoints")
                        .IsRequired();

                    b.Navigation("UserProgress");

                    b.Navigation("UserRewards");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
