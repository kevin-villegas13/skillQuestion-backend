using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillQuest_backend.Models.@enum;

namespace SkillQuest_backend.Models;

[Table("user_progress")]
public class UserProgress
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProgressId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public required User User { get; set; }

    [ForeignKey("Lesson")]
    public int LessonId { get; set; }
    public required Lesson Lesson { get; set; }

    [Required]
    public ProgressStatus Status { get; set; } 

    public int? Score { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}

