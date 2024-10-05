using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class// T es un marcador del repositorio de clases genéricas que se adapta a cada una de las entidades
    {
        T Get(int id);

        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, // obtener todos los registros repositorio generico
        Func<IQueryable<T>, IOrderedQueryable<T>>?orderBy = null,
        string? includeProperties = null);

        T GetFirtsOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        void Add(T entity);
        void Remove(int id);    
        void Remove(T entity);
        

    }
}
