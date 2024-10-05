using BlogCore.AccesoDatos.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;// declaramos el contexto
        internal DbSet<T> dbSet; // declaramos el Dbset
        public Repository(DbContext context)
        {
           Context = context;
           this.dbSet = context.Set<T>(); // asignamos el contexto al dbset con la inyeccion de dependencias
            
        }


        public void Add(T entity)
        {
           dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;// se crea una consulta IQueryable a partir del Dbset del contexto o lista de registros sin filtrar

            if(filter != null) // controlamos si se ha pasado un filtro
            {
                query = query.Where(filter);
            }

            if(includeProperties != null)// aqui controlamos si tiene data relacionada . Se icluyeb propiedades de navegación si se proporcionan
            {// se divide la propiedades por coma y se itera sobre ellas
                foreach(var includeProperty  in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }

            if(orderBy != null) // Aqui controlamos el ordenamiento de la data si se proporciona
            {
                return orderBy(query).ToList();// se ejecuta la función de ordenamiento y se saca una lista
            }
            // no se produce ordenamiento se genera una lista
            return query.ToList();
        }

        public T GetFirtsOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;// se crea una consulta IQueryable a partir del Dbset del contexto o lista de registros sin filtrar
            
            if (filter != null) // controlamos si se ha pasado un filtro
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)// aqui controlamos si tiene data relacionada . Se icluyeb propiedades de navegación si se proporcionan
            {// se divide la propiedades por coma y se itera sobre ellas
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
           T entityToRemove = dbSet.Find(id);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
