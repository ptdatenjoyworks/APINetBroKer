using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;
using Core.Repositories.Contract;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Windows;
using Microsoft.EntityFrameworkCore;


namespace Domain.Service.Contracts
{
    public class ContractItemService : IContractItemService
    {
        private readonly IContractItemRepository contractItemRepository;
        private IMapper mapper;
        private string FilePath = $"{AppDomain.CurrentDomain.BaseDirectory}ContractItemAttchments";
        
        public ContractItemService(IContractItemRepository contractItemRepository, IMapper mapper)
        {
            this.contractItemRepository = contractItemRepository;
            this.mapper = mapper;
        }
        public Task<ContractItemReponse> Create(ContractItemReponse entity)
        {
            throw new NotImplementedException();
        }
        public async Task<ContractItemReponse> Create (ContractItemRequest contractItemRequest)
        {
            if (contractItemRequest.IsActive)
            {
                var contractItem = mapper.Map<ContractItemRequest, ContractItem>(contractItemRequest);
                await contractItemRepository.CreateAsync(contractItem);
                await contractItemRepository.SaveAsync();
                var contractItemReponse = mapper.Map<ContractItemRequest, ContractItemReponse>(contractItemRequest);
                return contractItemReponse;
            }
            return null;
        }
        public async Task<bool> CreateContractItem([FromBody] ContractItemCreateRequest contractItemRequest)
        {
            
            try
            {
                if (contractItemRequest == null)
                {
                    throw new ArgumentNullException("ContractItem null");
                }
                if (contractItemRequest.ContractItemAttachment != null)
                {
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }
                    foreach (var file in contractItemRequest.ContractItemAttachment)
                    {
                        string fileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (fileExtension != ".pdf" && fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".doc" && fileExtension != ".docx")
                        {
                            throw new ArgumentNullException("ContractItem file not allow");
                        }
                        if (file.Length > 0)
                        {
                            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                          
                            string filePath = Path.Combine(FilePath, uniqueFileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Delete(int id)
        {
            var contractItem = await contractItemRepository.FindById(id);
            if (contractItem != null)
            {
                var result = mapper.Map<ContractItem, ContractItemRequest>(contractItem);
                result.IsActive = false;
                await Update(result);
                return true;
            }
            return false;
        }

        public async Task<List<ContractItemReponse>> GetAll()
        {
            var result = await contractItemRepository.FindByConditionAsyncs(x => x.IsActive).ProjectTo<ContractItemReponse>(mapper.ConfigurationProvider).ToListAsync();
            return result;
        }
       
        public async Task Update(ContractItemRequest entity)
        {
            var contract = await contractItemRepository.FindById(entity.Id);
            if (contract != null)
            {
                contract.Update(entity.ContractsId, entity.StartDate, entity.TermMonth, entity.ProductType, entity.EnergyUnitType);

                await contractItemRepository.SaveAsync();
            }
        }
    }
}
