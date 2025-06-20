using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interfaces
{
    public interface IInstanceService
    {
        public Task<int> AddAsync(AddInstanceDto instance, CancellationToken token);
        public Task<bool> UpdateAsync(UpdateInstanceDto instance, CancellationToken token);
        public Task<bool> DeleteAsync(int id, CancellationToken token);
        public Task<List<ShowInstanceWithoutDetailsDto>> GetAllAsync(CancellationToken token);
        public Task<ShowInstanceDto> GetAsync(int id, CancellationToken token);
    }
}
