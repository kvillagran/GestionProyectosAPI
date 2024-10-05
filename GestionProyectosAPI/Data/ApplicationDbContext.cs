using Microsoft.EntityFrameworkCore;
using GestionProyectosAPI.Models;

namespace GestionProyectosAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones uno a muchos

            // Un Equipo tiene muchos Proyectos
            modelBuilder.Entity<Proyecto>()
                .HasOne(p => p.Equipo)
                .WithMany(e => e.Proyectos)
                .HasForeignKey(p => p.EquipoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Un Proyecto tiene muchas Tareas
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Proyecto)
                .WithMany(p => p.Tareas)
                .HasForeignKey(t => t.ProyectoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración de Enum como string
            modelBuilder.Entity<Tarea>()
                .Property(t => t.Estado)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
