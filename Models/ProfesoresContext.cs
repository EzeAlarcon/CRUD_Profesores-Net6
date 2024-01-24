using Microsoft.EntityFrameworkCore;

namespace Crud_Profesores.Models
{
    // Clase que representa el contexto de la base de datos
    public class ProfesoresContext : DbContext
    {
        // Constructor que toma las opciones del contexto proporcionadas por el servicio de inyección de dependencias
        public ProfesoresContext(DbContextOptions<ProfesoresContext> options) : base(options)
        {
        }

        // DbSet que representa la tabla de profesores en la base de datos
        public DbSet<Profesores> Profesores { get; set; }

        // Método que se llama al crear el modelo de la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llama al método base para mantener el comportamiento predeterminado
            base.OnModelCreating(modelBuilder);

            // Configuración adicional del modelo, en este caso, se agrega un índice único a la propiedad "Name" de la entidad "Profesores"
            modelBuilder.Entity<Profesores>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
