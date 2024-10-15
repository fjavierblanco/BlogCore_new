using BlogCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface IArticuloRepository : IRepository<Articulo>// esta interface se pone a parte para actualizar  con SaveChange() las entidades que entity hace un seguimieto automatico 
    {
        void Update(Articulo articulo);
    }
}
