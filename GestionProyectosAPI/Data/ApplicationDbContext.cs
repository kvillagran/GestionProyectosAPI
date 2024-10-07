using Microsoft.EntityFrameworkCore;
using GestionProyectosAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GestionProyectosAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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

            // Seed para Equipos
            modelBuilder.Entity<Equipo>().HasData(
                new Equipo
                {
                    Id = 1,
                    Nombre = "Desarrollo",
                    Descripcion = "Equipo encargado de la programación y desarrollo de software."
                },
                new Equipo
                {
                    Id = 2,
                    Nombre = "Diseño",
                    Descripcion = "Equipo encargado del diseño gráfico y experiencia de usuario."
                },
                new Equipo
                {
                    Id = 3,
                    Nombre = "Operaciones",
                    Descripcion = "Equipo encargado de la infraestructura y soporte operativo."
                }
            );

            // Seed para Proyectos
            modelBuilder.Entity<Proyecto>().HasData(
                // Proyectos del Equipo Desarrollo (EquipoId = 1)
                new Proyecto
                {
                    Id = 1,
                    Nombre = "Plataforma Interna",
                    FechaInicio = new DateTime(2024, 1, 15),
                    FechaFin = new DateTime(2024, 5, 30),
                    EquipoId = 1
                },
                new Proyecto
                {
                    Id = 2,
                    Nombre = "Sistema de Automatización",
                    FechaInicio = new DateTime(2024, 3, 1),
                    FechaFin = new DateTime(2024, 8, 15),
                    EquipoId = 1
                },
                new Proyecto
                {
                    Id = 3,
                    Nombre = "Migración de Plataforma",
                    FechaInicio = new DateTime(2024, 2, 10),
                    FechaFin = new DateTime(2024, 7, 10),
                    EquipoId = 1
                },

                // Proyectos del Equipo Diseño (EquipoId = 2)
                new Proyecto
                {
                    Id = 4,
                    Nombre = "Rediseño Web Corporativo",
                    FechaInicio = new DateTime(2024, 4, 1),
                    FechaFin = new DateTime(2024, 9, 15),
                    EquipoId = 2
                },
                new Proyecto
                {
                    Id = 5,
                    Nombre = "Identidad Visual Nueva Marca",
                    FechaInicio = new DateTime(2024, 2, 20),
                    FechaFin = new DateTime(2024, 6, 30),
                    EquipoId = 2
                },
                new Proyecto
                {
                    Id = 6,
                    Nombre = "Diseño de Aplicación Móvil",
                    FechaInicio = new DateTime(2024, 3, 5),
                    FechaFin = new DateTime(2024, 8, 20),
                    EquipoId = 2
                },

                // Proyectos del Equipo Operaciones (EquipoId = 3)
                new Proyecto
                {
                    Id = 7,
                    Nombre = "Optimización de Redes",
                    FechaInicio = new DateTime(2024, 1, 10),
                    FechaFin = new DateTime(2024, 6, 15),
                    EquipoId = 3
                },
                new Proyecto
                {
                    Id = 8,
                    Nombre = "Automatización de Servidores",
                    FechaInicio = new DateTime(2024, 3, 25),
                    FechaFin = new DateTime(2024, 7, 5),
                    EquipoId = 3
                },
                new Proyecto
                {
                    Id = 9,
                    Nombre = "Migración de Datos a Nube",
                    FechaInicio = new DateTime(2024, 2, 15),
                    FechaFin = new DateTime(2024, 7, 1),
                    EquipoId = 3
                }
            );

            // Seed para Tareas
            modelBuilder.Entity<Tarea>().HasData(
                // Tareas para Proyecto 1: Plataforma Interna (ProyectoId = 1)
                new Tarea
                {
                    Id = 1,
                    Descripcion = "Planificación inicial",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 1
                },
                new Tarea
                {
                    Id = 2,
                    Descripcion = "Desarrollo de prototipos",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 1
                },
                new Tarea
                {
                    Id = 3,
                    Descripcion = "Implementación de módulos",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 1
                },
                new Tarea
                {
                    Id = 4,
                    Descripcion = "Pruebas de integración",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 1
                },
                new Tarea
                {
                    Id = 5,
                    Descripcion = "Despliegue inicial",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 1
                },

                // Tareas para Proyecto 2: Sistema de Automatización (ProyectoId = 2)
                new Tarea
                {
                    Id = 6,
                    Descripcion = "Recolección de requerimientos",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 2
                },
                new Tarea
                {
                    Id = 7,
                    Descripcion = "Diseño del sistema",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 2
                },
                new Tarea
                {
                    Id = 8,
                    Descripcion = "Configuración de servidores",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 2
                },
                new Tarea
                {
                    Id = 9,
                    Descripcion = "Pruebas de rendimiento",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 2
                },
                new Tarea
                {
                    Id = 10,
                    Descripcion = "Lanzamiento del sistema",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 2
                },

                // Tareas para Proyecto 3: Migración de Plataforma (ProyectoId = 3)
                new Tarea
                {
                    Id = 11,
                    Descripcion = "Evaluación de la plataforma actual",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 3
                },
                new Tarea
                {
                    Id = 12,
                    Descripcion = "Planificación de migración",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 3
                },
                new Tarea
                {
                    Id = 13,
                    Descripcion = "Implementación del nuevo sistema",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 3
                },
                new Tarea
                {
                    Id = 14,
                    Descripcion = "Transferencia de datos",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 3
                },
                new Tarea
                {
                    Id = 15,
                    Descripcion = "Pruebas finales",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 3
                },

                // Tareas para Proyecto 4: Rediseño Web Corporativo (ProyectoId = 4)
                new Tarea
                {
                    Id = 16,
                    Descripcion = "Investigación de usuario",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 4
                },
                new Tarea
                {
                    Id = 17,
                    Descripcion = "Creación de wireframes",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 4
                },
                new Tarea
                {
                    Id = 18,
                    Descripcion = "Diseño de interfaz de usuario",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 4
                },
                new Tarea
                {
                    Id = 19,
                    Descripcion = "Implementación de prototipos",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 4
                },
                new Tarea
                {
                    Id = 20,
                    Descripcion = "Pruebas de usabilidad",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 4
                },

                // Tareas para Proyecto 5: Identidad Visual Nueva Marca (ProyectoId = 5)
                new Tarea
                {
                    Id = 21,
                    Descripcion = "Desarrollo de conceptos",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 5
                },
                new Tarea
                {
                    Id = 22,
                    Descripcion = "Diseño de logo",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 5
                },
                new Tarea
                {
                    Id = 23,
                    Descripcion = "Creación de guías de estilo",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 5
                },
                new Tarea
                {
                    Id = 24,
                    Descripcion = "Elaboración de material promocional",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 5
                },
                new Tarea
                {
                    Id = 25,
                    Descripcion = "Presentación al cliente",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 5
                },

                // Tareas para Proyecto 6: Diseño de Aplicación Móvil (ProyectoId = 6)
                new Tarea
                {
                    Id = 26,
                    Descripcion = "Diseño de pantallas",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 6
                },
                new Tarea
                {
                    Id = 27,
                    Descripcion = "Creación de iconografía",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 6
                },
                new Tarea
                {
                    Id = 28,
                    Descripcion = "Pruebas de diseño",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 6
                },
                new Tarea
                {
                    Id = 29,
                    Descripcion = "Adaptación a diferentes dispositivos",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 6
                },
                new Tarea
                {
                    Id = 30,
                    Descripcion = "Revisión final de diseño",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 6
                },

                // Tareas para Proyecto 7: Optimización de Redes (ProyectoId = 7)
                new Tarea
                {
                    Id = 31,
                    Descripcion = "Auditoría de infraestructura",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 7
                },
                new Tarea
                {
                    Id = 32,
                    Descripcion = "Revisión de configuraciones actuales",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 7
                },
                new Tarea
                {
                    Id = 33,
                    Descripcion = "Implementación de mejoras",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 7
                },
                new Tarea
                {
                    Id = 34,
                    Descripcion = "Pruebas de conectividad",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 7
                },
                new Tarea
                {
                    Id = 35,
                    Descripcion = "Documentación de cambios",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 7
                },

                // Tareas para Proyecto 8: Automatización de Servidores (ProyectoId = 8)
                new Tarea
                {
                    Id = 36,
                    Descripcion = "Configuración de herramientas",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 8
                },
                new Tarea
                {
                    Id = 37,
                    Descripcion = "Desarrollo de scripts de automatización",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 8
                },
                new Tarea
                {
                    Id = 38,
                    Descripcion = "Pruebas de integración",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 8
                },
                new Tarea
                {
                    Id = 39,
                    Descripcion = "Documentación del proceso",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 8
                },
                new Tarea
                {
                    Id = 40,
                    Descripcion = "Implementación en producción",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 8
                },

                // Tareas para Proyecto 9: Migración de Datos a Nube (ProyectoId = 9)
                new Tarea
                {
                    Id = 41,
                    Descripcion = "Selección de plataforma",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 9
                },
                new Tarea
                {
                    Id = 42,
                    Descripcion = "Planificación de migración",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 9
                },
                new Tarea
                {
                    Id = 43,
                    Descripcion = "Transferencia de datos",
                    Estado = EstadoTarea.EnProgreso,
                    ProyectoId = 9
                },
                new Tarea
                {
                    Id = 44,
                    Descripcion = "Configuración de seguridad",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 9
                },
                new Tarea
                {
                    Id = 45,
                    Descripcion = "Pruebas y ajustes finales",
                    Estado = EstadoTarea.Pendiente,
                    ProyectoId = 9
                }
            );
        }
    }
}
