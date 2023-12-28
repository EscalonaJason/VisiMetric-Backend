
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

using System;
using System.ComponentModel.DataAnnotations;

[Table("WOUNDS", Schema = "visimetric")]
public class Wound
{
    public Guid Id { get; set; }

    [Required]
    public string Description { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}