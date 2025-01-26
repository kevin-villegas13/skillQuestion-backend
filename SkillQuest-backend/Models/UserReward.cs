using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillQuest_backend.Models;

[Table("user_rewards")]
public class UserReward
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserRewardId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public required User User { get; set; }

    [ForeignKey("Reward")]
    public int RewardId { get; set; }
    public required Reward Reward { get; set; }

    public DateTime? AcquiredAt { get; set; }
}

