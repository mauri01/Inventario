









using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace INVENTARIO.ENTITY
{
	public class INVENTARIOContext : DbContext
	{
		public INVENTARIOContext() : base("INVENTARIODB")
		{
            //Database.SetInitializer<INVENTARIOContext>(new INVENTARIOInitializer());
		}

		//Tablas
		public DbSet<Perfil> Perfil { set; get; }
		public DbSet<Usuario> Usuario { set; get; }
		public DbSet<Inventario> Inventario { set; get; }
		
		

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
             
		}
	}
}
