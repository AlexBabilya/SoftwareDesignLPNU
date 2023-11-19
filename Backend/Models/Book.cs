using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Books")]
public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Assuming Id is not auto-generated
    [Column("ID")] // Maps to the "ID" column in the database
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    [Column(TypeName = "datetime")]
    public DateTime PublicationDate { get; set; }

    [Required]
    public float Price { get; set; }

    [Required]
    [ForeignKey("AuthorId")]
    public int AuthorId { get; set; }

    [Required]
    [ForeignKey("PublisherId")]
    public int PublisherId { get; set; }
}

