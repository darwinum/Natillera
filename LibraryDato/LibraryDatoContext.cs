
using Microsoft.EntityFrameworkCore;
using ModelosEntidades.Models;
using System;

namespace LibraryDato
{
    public class LibraryDatoContext:DbContext
    {

        public LibraryDatoContext(DbContextOptions opcion) : base(opcion) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        /// <summary>
        /// entidad o tabla que se encarga de almacenar las diferentes natilleras que administrara el sistema.
        /// </summary>
        public DbSet<Natillera> Natilleras { get; set; }

        /// <summary>
        /// son las diferentes actividades que realiza la natillera para obtener veneficios extras, bingos, rifas etc.
        /// </summary>
        public DbSet<ActividadesRecaudo> ActividadesRecaudos { get; set; }

        /// <summary>
        /// tipos de identificacion o documentos de los socios.
        /// </summary>
        public DbSet<TiposDocumento> TiposDocumentos { get; set; }

        /// <summary>
        /// socios son las personas que pertenecen a la natillera y deben dar una cuota mensual.
        /// </summary>
        public DbSet<Socio> Socios { get; set; }
        /// <summary>
        /// almaneca la informacion de los prestamos que solicita un socio
        /// </summary>
        public DbSet<Prestamo> Prestamos { get; set; }
        /// <summary>
        /// son las cuotas pagadas para determinado prestamo.
        /// </summary>
        public DbSet<CuotasPrestamo> CuotasPrestamos { get; set; }
        /// <summary>
        /// son las cuotas que el socio debe dar segun mensual o quincenal dependiendo la parametrizacion.
        /// </summary>
        public DbSet<CuotasSocio> CuotasSocios { get; set; }        
       
    }
}
