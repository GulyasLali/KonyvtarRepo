using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealKonyvtar.Shared
{
    public class Konyv
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public required string Author { get; set; }

        public required string Publisher { get; set; }

        public int ReleaseYear { get; set; }

    }
}
