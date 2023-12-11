using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealKonyvtar.Shared
{
    public class Reader
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public required string Address { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "2023-1-1")]
        public required DateTime BirthDate { get; set; }


    }
}
