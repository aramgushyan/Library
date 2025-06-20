using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IReaderRepository
    {
        public Task<int> AddReaderAsync(Reader reader, CancellationToken token);
        public Task<bool> UpdateReaderAsync(int id, Reader reader, CancellationToken token);
        public Task<bool> DeleteReaderAsync(int id, CancellationToken token);
        public Task<List<Reader>> GetAllReadersAsync(CancellationToken token);
        public Task<Reader> GetReaderByIdAsync(int id, CancellationToken token);
        public Task<List<string>> GetActiveBookLendingsByReaderIdAsync(int id, CancellationToken token);

    }
}
