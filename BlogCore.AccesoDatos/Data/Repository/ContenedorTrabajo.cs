using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo // esto es una adastarción de una unidad de trabajo o Unity of Work de Microsoft
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;

            Categoria = new CategoriaRepository(_db);
            //Articulo = new ArticuloRepository(_db); 

        }

        public ICategoriaRepository Categoria { get; private set; }

        public void Dispose()
        {
           _db.Dispose();//Libera los recursos despues descargar la base
        }

        public void Save()
        {
           _db.SaveChanges();//guardamos los cambios
        }
    }
}
