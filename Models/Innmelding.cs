using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Karverket.Models
{
    public class Innmelding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Fylke { get; set; }
        public string GeoJson { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = "Pending";

        // Foreign key to the User table
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } // Navigation property
        public bool Prioritised { get; set; } = false; // Default to false
    }


}