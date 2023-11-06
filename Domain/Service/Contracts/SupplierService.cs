using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response;
using Core.Repositories.Contract;
using Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.Contracts
{
    public class SupplierService : ISupplierService
    {
        private ISuppilerRepository suppilerRepository;
        private IMapper mapper;
        private IContractRepository contractRepository;

        public SupplierService(ISuppilerRepository suppilerRepository, IMapper mapper, IContractRepository contractRepository)
        {
            this.suppilerRepository = suppilerRepository;
            this.mapper = mapper;
            this.contractRepository = contractRepository;
        }

        public async Task Create(SupplierRequest entity)
        {
            var supplier = mapper.Map<SupplierRequest, Supplier>(entity);
            var result = await suppilerRepository.CreateAsync(supplier);
            await suppilerRepository.SaveAsync();
        }

        public Task<SupplierResponse> Create(SupplierResponse entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var suppler = (await suppilerRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();

            if (suppler != null)
            {
                var result = mapper.Map<Supplier, SupplierRequest>(suppler);
                result.IsActive = false;
                await Update(result);
                return true;
            }
            return false;
        }

        public async Task<List<SupplierResponse>> GetAll()
        {
            var result = await suppilerRepository.FindAllAsync(p => p.Contracts).ProjectTo<SupplierResponse>(mapper.ConfigurationProvider).ToListAsync();
            return result;
        }

        public Task Update(SupplierResponse entity)
        {
            throw new NotImplementedException();
        }
        public async Task Update(SupplierRequest supplier)
        {
            var sup = await suppilerRepository.FindById(supplier.Id);
            if (sup != null)
            {
                sup.Update(supplier.Name, supplier.IsActive, supplier.Stage);
                await suppilerRepository.SaveAsync();
            }
        }
    }
}
