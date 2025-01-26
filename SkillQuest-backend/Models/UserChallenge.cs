

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillQuest_backend.Models.@enum;

namespace SkillQuest_backend.Models;

[Table("user_challenges")]
public class UserChallenge
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserChallengeId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public required User User { get; set; }

    [ForeignKey("Challenge")]
    public int ChallengeId { get; set; }
    public required Challenge Challenge { get; set; }

    [Required]
    public ChallengeStatus Status { get; set; }

    public DateTime? CompletedAt { get; set; }
}

