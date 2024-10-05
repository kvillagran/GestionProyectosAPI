using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionProyectosAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipos",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Equipo encargado de la programación y desarrollo de software.", "Desarrollo" },
                    { 2, "Equipo encargado del diseño gráfico y experiencia de usuario.", "Diseño" },
                    { 3, "Equipo encargado de la infraestructura y soporte operativo.", "Operaciones" }
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "EquipoId", "FechaFin", "FechaInicio", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Plataforma Interna" },
                    { 2, 1, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistema de Automatización" },
                    { 3, 1, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Migración de Plataforma" },
                    { 4, 2, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rediseño Web Corporativo" },
                    { 5, 2, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Identidad Visual Nueva Marca" },
                    { 6, 2, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diseño de Aplicación Móvil" },
                    { 7, 3, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Optimización de Redes" },
                    { 8, 3, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Automatización de Servidores" },
                    { 9, 3, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Migración de Datos a Nube" }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "Descripcion", "Estado", "ProyectoId" },
                values: new object[,]
                {
                    { 1, "Planificación inicial", "Pendiente", 1 },
                    { 2, "Desarrollo de prototipos", "EnProgreso", 1 },
                    { 3, "Implementación de módulos", "Pendiente", 1 },
                    { 4, "Pruebas de integración", "Pendiente", 1 },
                    { 5, "Despliegue inicial", "Pendiente", 1 },
                    { 6, "Recolección de requerimientos", "Pendiente", 2 },
                    { 7, "Diseño del sistema", "Pendiente", 2 },
                    { 8, "Configuración de servidores", "EnProgreso", 2 },
                    { 9, "Pruebas de rendimiento", "Pendiente", 2 },
                    { 10, "Lanzamiento del sistema", "Pendiente", 2 },
                    { 11, "Evaluación de la plataforma actual", "Pendiente", 3 },
                    { 12, "Planificación de migración", "EnProgreso", 3 },
                    { 13, "Implementación del nuevo sistema", "Pendiente", 3 },
                    { 14, "Transferencia de datos", "Pendiente", 3 },
                    { 15, "Pruebas finales", "Pendiente", 3 },
                    { 16, "Investigación de usuario", "Pendiente", 4 },
                    { 17, "Creación de wireframes", "Pendiente", 4 },
                    { 18, "Diseño de interfaz de usuario", "EnProgreso", 4 },
                    { 19, "Implementación de prototipos", "Pendiente", 4 },
                    { 20, "Pruebas de usabilidad", "Pendiente", 4 },
                    { 21, "Desarrollo de conceptos", "Pendiente", 5 },
                    { 22, "Diseño de logo", "Pendiente", 5 },
                    { 23, "Creación de guías de estilo", "EnProgreso", 5 },
                    { 24, "Elaboración de material promocional", "Pendiente", 5 },
                    { 25, "Presentación al cliente", "Pendiente", 5 },
                    { 26, "Diseño de pantallas", "Pendiente", 6 },
                    { 27, "Creación de iconografía", "Pendiente", 6 },
                    { 28, "Pruebas de diseño", "Pendiente", 6 },
                    { 29, "Adaptación a diferentes dispositivos", "EnProgreso", 6 },
                    { 30, "Revisión final de diseño", "Pendiente", 6 },
                    { 31, "Auditoría de infraestructura", "Pendiente", 7 },
                    { 32, "Revisión de configuraciones actuales", "Pendiente", 7 },
                    { 33, "Implementación de mejoras", "EnProgreso", 7 },
                    { 34, "Pruebas de conectividad", "Pendiente", 7 },
                    { 35, "Documentación de cambios", "Pendiente", 7 },
                    { 36, "Configuración de herramientas", "Pendiente", 8 },
                    { 37, "Desarrollo de scripts de automatización", "Pendiente", 8 },
                    { 38, "Pruebas de integración", "EnProgreso", 8 },
                    { 39, "Documentación del proceso", "Pendiente", 8 },
                    { 40, "Implementación en producción", "Pendiente", 8 },
                    { 41, "Selección de plataforma", "Pendiente", 9 },
                    { 42, "Planificación de migración", "Pendiente", 9 },
                    { 43, "Transferencia de datos", "EnProgreso", 9 },
                    { 44, "Configuración de seguridad", "Pendiente", 9 },
                    { 45, "Pruebas y ajustes finales", "Pendiente", 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Tareas",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Proyectos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
