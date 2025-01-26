using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkillQuest_backend.Models;

[Table("rewards")]
public class Reward
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RewardId { get; set; }

    [Required]
    [StringLength(255)]
    public string? Title { get; set; }

    public string? Description { get; set; }
    public int PointsRequired { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public required ICollection<UserReward> UserRewards { get; set; }
}

