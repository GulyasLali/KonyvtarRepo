using Microsoft.EntityFrameworkCore;
using RealKonyvtar.Shared;

namespace RealKonyvtar.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }

        public DbSet<Konyv> Konyvek {  get; set; }
    }
}
