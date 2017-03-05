using INVENTARIO.ENTITY.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTARIO.ENTITY
{
    public class Usuario : IEntity
    {
        public int usuarioId { set; get; }
        public string nombre { set; get; }
        public string email { set; get; }
        public string apellido { set; get; }
        public string direccion { set; get; }
        public int telefono { set; get; }
        public int perfilId { set; get; }
        public virtual Perfil perfil { set; get; }
    }
}
