using Microsoft.EntityFrameworkCore;
using SkillQuest_backend.Models;

namespace SkillQuest_backend.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public required DbSet<User> Users { get; set; }
    public required DbSet<Role> Roles { get; set; }
    public required DbSet<UserRole> UserRoles { get; set; }
    public required DbSet<Course> Courses { get; set; }
    public required DbSet<Lesson> Lessons { get; set; }
    public required DbSet<UserProgress> UserProgresses { get; set; }
    public required DbSet<Challenge> Challenges { get; set; }
    public required DbSet<UserChallenge> UserChallenges { get; set; }
    public required DbSet<Reward> Rewards { get; set; }
    public required DbSet<UserReward> UserRewards { get; set; }
    public required DbSet<UserPoints> UserPoints { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación entre User y UserRoles (1 a muchos)
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // Relación entre User y UserProgress (1 a muchos)
        modelBuilder.Entity<UserProgress>()
            .HasKey(up => up.ProgressId);

        modelBuilder.Entity<UserProgress>()
            .HasOne(up => up.User)
            .WithMany(u => u.UserProgress)
            .HasForeignKey(up => up.UserId);

        modelBuilder.Entity<UserProgress>()
            .HasOne(up => up.Lesson)
            .WithMany(l => l.UserProgress)
            .HasForeignKey(up => up.LessonId);

        // Relación entre User y UserChallenges (1 a muchos)
        modelBuilder.Entity<UserChallenge>()
            .HasKey(uc => uc.UserChallengeId);

        modelBuilder.Entity<UserChallenge>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserChallenges)
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<UserChallenge>()
            .HasOne(uc => uc.Challenge)
            .WithMany(c => c.UserChallenges)
            .HasForeignKey(uc => uc.ChallengeId);

        // Relación entre User y UserRewards (1 a muchos)
        modelBuilder.Entity<UserReward>()
            .HasKey(ur => ur.UserRewardId);

        modelBuilder.Entity<UserReward>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRewards)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserReward>()
            .HasOne(ur => ur.Reward)
            .WithMany(r => r.UserRewards)
            .HasForeignKey(ur => ur.RewardId);

        // Relación entre User y UserPoints (1 a 1)
        modelBuilder.Entity<UserPoints>()
            .HasKey(up => up.UserId);

        modelBuilder.Entity<UserPoints>()
            .HasOne(up => up.User)
            .WithOne(u => u.UserPoints)
            .HasForeignKey<UserPoints>(up => up.UserId);

        // Relación entre Role y UserRoles (1 a muchos)
        modelBuilder.Entity<Role>()
            .HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId);

        // Relación entre Lesson y UserProgress (1 a muchos)
        modelBuilder.Entity<Lesson>()
            .HasMany(l => l.UserProgress)
            .WithOne(up => up.Lesson)
            .HasForeignKey(up => up.LessonId);

        // Relación entre Challenge y UserChallenges (1 a muchos)
        modelBuilder.Entity<Challenge>()
            .HasMany(c => c.UserChallenges)
            .WithOne(uc => uc.Challenge)
            .HasForeignKey(uc => uc.ChallengeId);

        // Relación entre Reward y UserRewards (1 a muchos)
        modelBuilder.Entity<Reward>()
            .HasMany(r => r.UserRewards)
            .WithOne(ur => ur.Reward)
            .HasForeignKey(ur => ur.RewardId);
    }
}
