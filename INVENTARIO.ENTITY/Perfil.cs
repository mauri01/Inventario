using INVENTARIO.ENTITY.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTARIO.ENTITY
{
    public class Perfil : IEntity
    {
        public int perfilId { get; set; }
        public string descripcion { set; get; }  
    }
}
