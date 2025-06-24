using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface ILoadRepository
    {
        /// <summary>
        /// Возвращает все таблицы из контекста.
        /// </summary>
        /// <returns>
        /// Таблицы из контекста.
        /// </returns>
        public IEnumerable<IEnumerable<object>> GetTables();
    }
}
