









using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTARIO.ENTITY.Repository;
using INVENTARIO.ENTITY.Repository.Interface;

namespace INVENTARIO.ENTITY
{
	public class UnitOfWork: IUnitOfWork, IDisposable
	{
		private INVENTARIOContext context = new INVENTARIOContext();
		
		
		private Repository<Perfil> perfilRepository;
		public IRepository<Perfil> PerfilRepository
		{
			get
			{
				if (this.perfilRepository == null)
				{
					this.perfilRepository = new Repository<Perfil>(context);
				}
				return perfilRepository;
			}
		}
		
		
		private Repository<Usuario> usuarioRepository;
		public IRepository<Usuario> UsuarioRepository
		{
			get
			{
				if (this.usuarioRepository == null)
				{
					this.usuarioRepository = new Repository<Usuario>(context);
				}
				return usuarioRepository;
			}
		}
		
		
		private Repository<Inventario> inventarioRepository;
		public IRepository<Inventario> InventarioRepository
		{
			get
			{
				if (this.inventarioRepository == null)
				{
					this.inventarioRepository = new Repository<Inventario>(context);
				}
				return inventarioRepository;
			}
		}
		
		
		
		

        public int Save()
		{
			return context.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

	}
}
