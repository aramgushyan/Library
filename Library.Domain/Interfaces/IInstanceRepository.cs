using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IInstanceRepository
    {
        public Task<int> AddInstanceAsync(Instance instance, CancellationToken token);
        public Task<bool> UpdateInstanceAsync(int id, Instance instance, CancellationToken token);
        public Task<bool> DeleteInstanceAsync(int id, CancellationToken token);
        public Task<List<Instance>> GetAllInstancesAsync(CancellationToken token);
        public Task<Instance> GetInstanceByIdAsync(int id, CancellationToken token);
    }
}
