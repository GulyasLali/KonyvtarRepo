using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace konyvtarProj.Server.Models
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibNumber { get; set; }
        public required string Name {  get; set; }
       public required string Author { get; set; }
       public required string Publisher { get; set; }
       public required DateTime PublishDate { get; set; }

    }
}
