using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Karverket.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //sikre på at de er AUTO-INCREMENT

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Fylke { get; set; }
        public string Role { get; set; } = "BRUKER"; // BRUKER or SAKSBEHANDLER or ADMIN. BAD DB DESIGN SHOULD BE IT'S OWN TABLE


        // TODO: en måte å skille politi, osv. 
    }
}
