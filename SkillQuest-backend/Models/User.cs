using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SkillQuest_backend.Models;

[Table("user")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    [StringLength(255)]
    public string? Username { get; set; }

    [Required]
    [StringLength(255)]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? PasswordHash { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }

    public ICollection<UserRole> UserRoles { get; set; } = [];
    public required ICollection<UserProgress> UserProgress { get; set; } = [];
    public required ICollection<UserChallenge> UserChallenges { get; set; } = [];
    public required ICollection<UserReward> UserRewards { get; set; } = [];
    public required UserPoints UserPoints { get; set; }
}