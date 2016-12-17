    using Caso_Estudio.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Caso_Estudio.DAL
{
    public class VideoClubContext : DbContext
    {
        public VideoClubContext() : base("VideoClubContext")
        {

        }

        public DbSet<VideoClub> VideoClubs { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<Administrador> Administradores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }        
    }
}