using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

using System.ComponentModel.DataAnnotations;

[Table("USERS", Schema = "visimetric")]
public class User
{
    [Key]
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("FirstName")]
    public string FirstName { get; set; }

    [Required]
    [Column("LastName")]
    public string LastName { get; set; }

    [Column("Title")]
    public string Title { get; set; }

    [Required]
    [Column("Password")]
    [MinLength(8, ErrorMessage = "Password must contain 8 or more characters.")]
    public string Password { get; set; }
    
    public List<Wound> Wounds { get; set; }
}




//  Wound-Table
//      ID: GUID, unique primary key
//      Description: String/Varchar, Not null
//      User-ID: int, Foreign key to User-ID(int), not null
//      Length: double
//      Width: double
//      Area: double
//      Date: datetime
//      Picture: varbinary

//  How to implement the Wound-History? 
//      Statistics-Table, with the statistics-data 
//          Primary-Key will be an int autoincrement; 
//          additionally there will be another identification-column with the identifier from the wound-table
//          multiple entries for one wound
//          Main table will not contain the date, the length, the width, the area, the picture, and other statistics
//          This data will be stored in this statistics-data
//
//      Everything into one table:
//          Int autoincrement, which is unique as identifier
//          The Guid, which can have multiple entries as grouping-tool for each wound
//          Every Statistic and picture will be stored in this table (Like the "Wound-Table" from above)

//
