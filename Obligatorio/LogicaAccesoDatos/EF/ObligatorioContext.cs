using LogicaNegocio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.EF
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }

        public ObligatorioContext() { }
        public ObligatorioContext(DbContextOptions<ObligatorioContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pago>().ToTable("Pagos").HasDiscriminator<string>("TipoPago").HasValue<Unico>("Unico").HasValue<Recurrente>("Recurrente");

            modelBuilder.Entity<Usuario>().HasOne(u => u.Equipo).WithMany().HasForeignKey("IdEquipo").OnDelete(DeleteBehavior.Restrict); //OnDelete(DeleteBehavior.Restrict) evita borrar en cascada

            modelBuilder.Entity<Pago>().HasOne(p => p.Usuario).WithMany().HasForeignKey("IdUsuario").OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pago>().HasOne(p => p.Gasto).WithMany().HasForeignKey("IdGasto").OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Auditoria>().HasOne(a => a.Usuario).WithMany().HasForeignKey("IdUsuario").OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Initial Catalog=BaseObligatorio; Integrated Security=true;");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
