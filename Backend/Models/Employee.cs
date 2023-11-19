using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table ("Employees")]
public class Employee 
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Assuming Id is not auto-generated
    [Column("ID")] // Maps to the "ID" column in the database
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required]
    [ForeignKey("DepartmentID")]
    public int DepartmentID { get; set; }

    [Required]
    public DateTime HireDate{ get; set; }

    [Required]
    public float Salary{ get; set; }

}



