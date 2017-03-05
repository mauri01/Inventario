using INVENTARIO.ENTITY.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTARIO.ENTITY
{
    public class Inventario : IEntity
    {
        public int inventarioId { set; get; }
        public string producto { set; get; }
        public string marca { set; get; }
        public string modelo { set; get; }
        public int cantidad { set; get; }
        public int precio { set; get; }
        public int usuarioId { set; get; }
        public virtual Usuario usuario { set; get; }
    }
}
