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
        public async Task<ContractReponse> Create(ContractRequest contractRequest)
        {
            var contract = mapper.Map<ContractRequest, Core.Entities.Contract.Contract>(contractRequest);
            await contractRepository.CreateAsync(contract);
            await contractRepository.SaveAsync();
            var result = mapper.Map<Contract, ContractReponse>(contract);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var contract = await contractRepository.FindById(id);
            if (contract != null)
            {
                contract.Delete();
                await contractRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ContractReponse>> GetAll()
        {
            var results = await contractRepository.FindByConditionAsyncs(x => x.IsActive).ProjectTo<ContractReponse>(mapper.ConfigurationProvider).ToListAsync();
            return results;
        }
        public async Task Update(ContractRequest entity)
        {
            var contract = await contractRepository.FindById(entity.Id);
            if (contract != null)
            {
                contract.Update(entity.LegalEntityName, entity.Stage, entity.CustomerId, entity.SupplierId);

                await contractRepository.SaveAsync();
            }
        }

      /*  public async Task<(bool,string)> VerifityContract(int id)
        {
            var contract = await contractRepository.FindById(id);
            if (!contract.ContractItems.Any())
            {
                return (false, "not have contract item");
            }
            foreach (var item in contract.ContractItems)
            {
                if (item.Status == Status.None || item.Status == Status.Rejected)
                {
                    item.ForecastState = item.Status == Status.None ? ForecastState.InvalidSalesData : ForecastState.RejectedDeal;
                    await contractRepository.SaveAsync();
                    return (false, "contract item status none");
                }
                if (item.Contracts == null)
                {
                    item.ForecastState = ForecastState.InvalidSalesData;
                }
                if (item.SalesProgram == null)
                {
                    item.ForecastState = ForecastState.MissingSalesProgram;
                }
                int qualificationsEnable = 0;
                foreach (var quafi in item.SalesProgram.Qualifications)
                {
                    if (quafi.QualificationVerifity()) { qualificationsEnable++; }
                }
                if (qualificationsEnable < 0)
                {
                    item.ForecastState = ForecastState.MissingSalesProgram;
                }


            }

            return (true, "");
        }*/
    }
}
