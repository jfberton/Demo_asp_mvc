using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Contexto:DbContext
    {
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Detalle_venta> Detalles_venta { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Venta>().ToTable("Venta");
            modelBuilder.Entity<Detalle_venta>().ToTable("Detalle_venta");
        }
    }
}
