









using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INVENTARIO.ENTITY.Repository.Interface;

namespace INVENTARIO.ENTITY
{
	public interface IUnitOfWork
	{
		IRepository<Perfil> PerfilRepository {get;}
		IRepository<Usuario> UsuarioRepository {get;}
		IRepository<Inventario> InventarioRepository {get;}
		
		
		int Save();
	}
}