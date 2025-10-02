using Microsoft.EntityFrameworkCore;
using Payment_manager.Domain.Entities;

namespace Payment_manager.Application.Data
{
    public class AppDbContext :DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        //tablas

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVenta { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Retiro> Retiros { get; set; }
        public DbSet<Comision> Comisiones { get; set; }
        public DbSet<CajaChica> CajaChica { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Venta)
                .WithMany(v => v.Pagos)
                .HasForeignKey(p => p.VentaId)
                .OnDelete(DeleteBehavior.Restrict); // ← evita el ciclo de cascada

        



            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }



    }
}
