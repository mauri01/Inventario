









using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INVENTARIO.ENTITY
{
    public class INVENTARIOInitializer: IDatabaseInitializer<INVENTARIOContext>
    {
        public bool nueva=false;
        public void InitializeDatabase(INVENTARIOContext context)
        {
            bool dbExists;
            dbExists = context.Database.Exists();
            if (dbExists)
            {
                try
                {
                    if (!context.Database.CompatibleWithModel(true))
                    {
                        throw new Exception("La base de datos existe y no es compatible...");
                    }
                }
                catch
                {
                    return;
                }
            }
            else
            {
                context.Database.Create();
                context.SaveChanges();
                nueva = true;
                return;
            }
            return;
        }

       
        public void CreateUser(INVENTARIOContext context)
        {
            
        }

        protected void Seed(INVENTARIOContext context)
        
        {

        }
    }
}