using AutoMapper;
using Core.Models.Requests.Contract;
using Core.Services.Contracts;
using Domain.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace APINetBorker.Controllers
{
    [Route("api/contractItem")]
    [AllowAnonymous]
    public class ContractItemController : ApiControllerBase
    {
        private readonly IMapper mapper;
        private IContractItemService contractItemService;

        public ContractItemController(IMapper mapper, IContractItemService contractItemService)
        {
            this.mapper = mapper;
            this.contractItemService = contractItemService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await contractItemService.GetAll();
            return CreateSuccessResult(contracts);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Create([FromForm] ContractItemCreateRequest contractItemRequest)
        {
            var result = await contractItemService.CreateContractItem(contractItemRequest);
            return result ? CreateSuccessResult("Create Success") : CreateFailResult("Create faild");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await contractItemService.Delete(id);

            return CreateSuccessResult(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromForm] ContractItemRequest contractItemRequest)
        {
            contractItemRequest.Id = id;    
            var result = await contractItemService.Update(contractItemRequest, false);
            return CreateSuccessResult(result);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("contractItemAttachment/{id}")]

        public async Task<IActionResult> DownloadContractItemAttachment (int id)
        {
            var path = await contractItemService.DownloadContractItemAttachment(id);
            if (string.IsNullOrEmpty(path) || !System.IO.File.Exists(path))
            {
                 return CreateFailResult("file not found");
            }
            
            var filebyte = System.IO.File.ReadAllBytes(path);
            var filename = Path.GetFileName(path);
            File(filebyte, "application/octet-stream", filename);
            return CreateSuccess();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("contractItemAttachments/{id}")]

        public async Task<IActionResult> DownloadAllAttachment(int id)
        {
            try
            {
                var attachments = await contractItemService.DownloadAllContractItemAttachments(id);
                if (attachments == null)
                {
                    return CreateFailResult("file not found");
                }

                using (var memoryStream = new MemoryStream())
                {
                    // Create a new zip archive
                    using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        foreach (var attachment in attachments)
                        {
                            var fileInfo = new FileInfo(attachment.Path);

                            // Create a new entry in the zip archive for each file
                            var entry = zipArchive.CreateEntry(fileInfo.Name);

                            // Write the file contents into the entry
                            using (var entryStream = entry.Open())
                            using (var fileStream = new FileStream(attachment.Path, FileMode.Open, FileAccess.Read))
                            {
                                fileStream.CopyTo(entryStream);
                            }
                        }
                    }

                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Return the zip file as a byte array
                    return File(memoryStream.ToArray(), "application/zip", "files.zip");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
         
        }
    }
}
