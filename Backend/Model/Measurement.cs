using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Model;

[Table("MEASUREMENTS", Schema = "visimetric")]
public class Measurement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Autoincrement, primary key
    public int Id { get; set; }

    [Column(TypeName = "varchar(90)")]
    public string WoundId { get; set; } // Will be guid

    [Required]
    public float Length { get; set; }

    [Required]
    public float Width { get; set; }

    [Required]
    public float Area { get; set; }

    [Required]
    public DateTime Date { get; set; }
    
    public byte[]? Picture { get; set; }
    
    
    public Wound Wound { get; set; }
}
