
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

using System;
using System.ComponentModel.DataAnnotations;

[Table("WOUNDS", Schema = "visimetric")]
public class Wound
{
    [Column(TypeName = "varchar(90)")]
    public string Id { get; set; } // Will be a guid

    [Required]
    public string Description { get; set; }

    [Required]
    public int UserId { get; set; }

    public User User { get; set; }
    public List<Measurement> Measurements { get; set; }
}