using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvtarProj.Shared.Models
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibNumber { get; set; }
        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string Publisher { get; set; }
        public required DateTime PublishDate { get; set; }

    }
}
