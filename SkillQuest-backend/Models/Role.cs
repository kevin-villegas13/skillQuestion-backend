using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SkillQuest_backend.Models.@enum;

namespace SkillQuest_backend.Models;

[Table("roles")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }

    [Required]
    [EnumDataType(typeof(RoleName))]
    public RoleName RoleName { get; set; }

    public required ICollection<UserRole> UserRoles { get; set; }
}

