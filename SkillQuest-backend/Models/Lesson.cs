using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillQuest_backend.Models;

[Table("lessons")]
public class Lesson
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LessonId { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public required Course Course { get; set; }

    [Required]
    [StringLength(255)]
    public string? Title { get; set; }

    public string? Content { get; set; }
    public int? DurationMinutes { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public required ICollection<UserProgress> UserProgress { get; set; }
}

