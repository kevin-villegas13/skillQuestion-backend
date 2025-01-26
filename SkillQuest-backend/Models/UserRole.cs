using System.ComponentModel.DataAnnotations.Schema;

namespace SkillQuest_backend.Models;

[Table("user_roles")]
public class UserRole
{
    [ForeignKey("User")]
    public int UserId { get; set; }
    public required User User { get; set; } 

    [ForeignKey("Role")]
    public int RoleId { get; set; }
    public required Role Role { get; set; }
}

