using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table ("Authors")]
public class Author
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
    public DateTime Birthdate { get; set; }

    [Required]
    [MaxLength(3)] // Assuming the maximum length for Nationality is 3 characters
    public string Nationality { get; set; }

}


