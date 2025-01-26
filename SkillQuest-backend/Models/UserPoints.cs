using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SkillQuest_backend.Models;

[Table("user_points")]
public class UserPoints
{
    [Key]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public required User User { get; set; }

    public int TotalPoints { get; set; } = 0;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

