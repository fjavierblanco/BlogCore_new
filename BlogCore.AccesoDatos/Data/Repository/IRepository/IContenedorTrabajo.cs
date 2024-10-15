using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable // indica que esta clase implementa un método Dispose
    {
        // Aquí se deben ir agregando los diferentes repositorios o metodos

        ICategoriaRepository Categoria { get; }//Llamamos  repositorio para que se pueda leer
        IArticuloRepository Articulo { get; }//Llamamos  repositorio para que se pueda leer

        void Save();





    }
}
