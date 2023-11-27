using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;
using Core.Repositories.Contract;
using Core.Services;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Service.Contracts
{
    public class ContractItemService : IContractItemService
    {
        private readonly IContractItemRepository contractItemRepository;
        private readonly IContractItemActtachmentRepository contractItemActtachmentRepository;
        private readonly IFileService fileService;
        private IMapper mapper;
        private string FilePath = $"{AppDomain.CurrentDomain.BaseDirectory}ContractItemAttchments";

        public ContractItemService(IContractItemRepository contractItemRepository, IContractItemActtachmentRepository contractItemActtachmentRepository, IMapper mapper, IFileService fileService)
        {
            this.contractItemRepository = contractItemRepository;
            this.mapper = mapper;
            this.contractItemActtachmentRepository = contractItemActtachmentRepository;
            this.fileService = fileService;
        }
        public Task<ContractItemReponse> Create(ContractItemReponse entity)
        {
            throw new NotImplementedException();
        }
        public async Task<ContractItemReponse> Create(ContractItemRequest contractItemRequest)
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
        public async Task<bool> CreateContractItem(ContractItemCreateRequest contractItemRequest)
        {

            try
            {
                if (contractItemRequest == null)
                {
                    throw new ArgumentNullException("ContractItem null");
                }
                if (contractItemRequest.ContractItemAttachment != null)
                {

                    var contractItem = mapper.Map<ContractItemCreateRequest, ContractItem>(contractItemRequest);

                    foreach (var file in contractItemRequest.ContractItemAttachment)
                    {
                        string fileExtension = Path.GetExtension(file.FileName).ToLower();
                        if (fileExtension != ".pdf" && fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".doc" && fileExtension != ".docx")
                        {
                            throw new ArgumentNullException("ContractItem file not allow");
                        }
                        double filesize = (double)file.Length / (1024 * 1024 * 1024);
                        if (filesize > 2)
                        {
                            throw new ArgumentNullException("attachment file size too big");
                        }
                        if (file.Length > 0)
                        {
                            var filePath = await fileService.SaveFileAttachment(file);
                            var fileName = Path.GetFileName(filePath);
                            var attachment = new ContractItemAttchment(fileName, contractItem.Id);
                            contractItem.Attachments.Add(attachment);
                        }
                    }
                    await contractItemRepository.CreateAsync(contractItem);
                    await contractItemRepository.SaveAsync();
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
                await Update(result, true);
                return true;
            }
            return false;
        }

        public async Task<List<ContractItemReponse>> GetAll()
        {
            var result = await contractItemRepository.FindByConditionAsyncs(x => x.IsActive).ProjectTo<ContractItemReponse>(mapper.ConfigurationProvider).ToListAsync();
            return result;
        }

        public async Task<bool> Update(ContractItemRequest entity, bool isDelete)
        {
            var contract = await contractItemRepository.Find(x => x.Id == entity.Id, p => p.Attachments);
            if (contract != null)
            {
                contract.Update(entity.ContractsId, entity.StartDate, entity.TermMonth, entity.ProductType, entity.EnergyUnitType);
                contract.IsActive = !isDelete;

                //file moi id=0
                var newFiles = entity.Attachments.Where(x => x.Id == 0).ToList();
                foreach (var file in newFiles)
                {
                    var filepath = await fileService.SaveFileAttachment(file?.File);
                    var fileName = Path.GetFileName(filepath);
                    var attachment = new ContractItemAttchment(fileName, contract.Id);
                    contract.Attachments.Add(attachment);
                }
                //xoa file id co trong db nhung ko có trong list submit
                var listIdDb = contract.Attachments.Select(x => x.Id);
                var listIdSummit = entity.Attachments.Select(x => x.Id);
                var deleteAttachment = listIdDb.Except(listIdSummit).ToList();
                if (deleteAttachment.Any())
                {
                    foreach (var attachmentId in deleteAttachment)
                    {
                        var attachment = contract.Attachments.FirstOrDefault(x => x.Id == attachmentId);
                        contract.Attachments.Remove(attachment);
                    }
                }
                await contractItemRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public Task Update(ContractItemRequest entity)
        {
            throw new NotImplementedException();
        }

        public async Task<(string, byte[])> DownloadContractItemAttachment(int id)
        {
            var contractItemAttachment = await contractItemActtachmentRepository.FindById(id);
            if (contractItemAttachment == null)
            {
                throw new ArgumentNullException("Contract Item Attachment not found");
            }

            var filebyte = fileService.GetFileDownload(contractItemAttachment.Path);
            var fileName = Path.GetFileName(contractItemAttachment.Path);
            return (fileName, filebyte);
        }

        public async Task DownloadAllContractItemAttachments(int id, Stream stream)
        {
            var contractItem = await contractItemActtachmentRepository.FindByConditionAsync(x => x.ContractItemId == id);
            if (contractItem.Any())
            {
                var listFile = contractItem.Select(x => x.Path).ToList();

                await fileService.GetAllFileDownload(listFile, stream);
                return;
            }
            throw new ArgumentNullException("not have file download");
        }
    }
}
