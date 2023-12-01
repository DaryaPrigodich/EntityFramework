using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseInteraction.Models.HumanResources;

[Table("Department", Schema = "HumanResources")]
public record Department()
{
    [Key]
    [Column("DepartmentID")]
    public short DepartmentId { get; set; }

    public string? Name { get; set; }
    
    public string? GroupName { get; set; } 

    public DateTime ModifiedDate { get; set; } 
}