﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillQuest_backend.Models;

[Table("challenges")]
public class Challenge
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ChallengeId { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public required Course Course { get; set; }

    [Required]
    [StringLength(255)]
    public string? Title { get; set; }

    public string? Description { get; set; }
    public int PointsReward { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public required ICollection<UserChallenge> UserChallenges { get; set; }
}

