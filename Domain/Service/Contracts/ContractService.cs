using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities.Contract;
using Core.Entities.Enum;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;
using Core.Repositories.Contract;
using Core.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.Contracts
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository contractRepository;
        private IMapper mapper;

        public ContractService(IContractRepository contractRepository, IMapper mapper)
        {
            this.contractRepository = contractRepository;
            this.mapper = mapper;
        }
        public async Task<bool> Create(ContractRequest contractRequest)
        {
            if (contractRequest.IsActive)
            {
                var contract = mapper.Map<ContractRequest, Core.Entities.Contract.Contract>(contractRequest);
                await contractRepository.CreateAsync(contract);
                await contractRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public Task<ContractReponse> Create(ContractReponse entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var contract = await contractRepository.FindById(id);
            if (contract != null)
            {
                var result = mapper.Map<Contract, ContractRequest>(contract);
                result.IsActive = false;
                await Update(result);
                return true;
            }
            return false;
        }

        public async Task<List<ContractReponse>> GetAll()
        {
            var results = await contractRepository.FindByConditionAsyncs(x => x.IsActive).ProjectTo<ContractReponse>(mapper.ConfigurationProvider).ToListAsync();
            return results;
        }

        public async Task Update(ContractReponse entity)
        {
            throw new NotImplementedException();
        }
        public async Task Update(ContractRequest entity)
        {
            var contract = await contractRepository.FindById(entity.Id);
            if (contract != null && entity.Stage == Stage.Opportunity)
            {
                contract.Update(entity.LegalEntityName, entity.IsActive, entity.Stage, entity.CustomerId, entity.SupplierId);

                await contractRepository.SaveAsync();
            }
        }
    }
}
