using Microsoft.EntityFrameworkCore;
using TrabajoFinal.Models;

namespace TrabajoFinal.Data
{
    public class FrutaContexto : DbContext
    {
        public FrutaContexto(DbContextOptions<FrutaContexto> options)
            : base(options)
        {
        }

        public DbSet<Fruta> Fruta { get; set; }
    }
}