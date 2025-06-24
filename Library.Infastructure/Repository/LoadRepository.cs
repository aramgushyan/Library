using Library.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infastructure.Repository
{
    public class LoadRepository:ILoadRepository
    {

        private readonly LibraryDbContext _context;

        public LoadRepository(LibraryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает все таблицы из контекста.
        /// </summary>
        /// <returns>
        /// Таблицы из контекста.
        /// </returns>
        public IEnumerable<IEnumerable<object>> GetTables() 
        {
            List<List<object>> tables = new List<List<object>>();


            var proper = _context.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType.Name.StartsWith("DbSet"));

            foreach (var property in proper) 
            {
                var set = property.GetValue(_context);

                if(set is IQueryable queryable)
                    tables.Add(queryable.Cast<object>().ToList());
            }

            return tables;
        } 
    }
}
