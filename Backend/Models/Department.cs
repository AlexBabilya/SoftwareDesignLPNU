using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Departments")]
public class Department 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Assuming Id is not auto-generated
    [Column("ID")] // Maps to the "ID" column in the database
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name{ get; set; }
    
    [MaxLength(255)]
    public string Location { get; set; }
}

