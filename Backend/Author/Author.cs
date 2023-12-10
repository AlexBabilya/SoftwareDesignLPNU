using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table ("Authors")]
public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    [Column("ID")] 
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
    [MaxLength(3)]
    public string Nationality { get; set; }

}


