using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillQuest_backend.Models;

[Table("courses")]
public class Course
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourseId { get; set; }

    [Required]
    [StringLength(255)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public required ICollection<Lesson> Lessons { get; set; }
    public required ICollection<Challenge> Challenges { get; set; }
}

