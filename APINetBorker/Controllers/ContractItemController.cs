using AutoMapper;
using Core.Models.Requests.Contract;
using Core.Services;
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
        private IFileService fileService;

        public ContractItemController(IMapper mapper, IContractItemService contractItemService, IFileService fileService)
        {
            this.mapper = mapper;
            this.contractItemService = contractItemService;
            this.fileService = fileService;
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

        public async Task<IActionResult> DownloadContractItemAttachment(int id)
        {
            var path = await contractItemService.DownloadContractItemAttachment(id);
            var filebyte = fileService.GetFileDownload(path);
            var filename = Path.GetFileName(path);
            return File(filebyte, "application/octet-stream", filename);
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

                var listFile = attachments.Select(x => x.Path).ToList();

                var memoryStream = fileService.GetAllFileDownload(listFile);

                // Return the zip file as a byte array
                return File(memoryStream.ToArray(), "application/zip", "files.zip");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }


    }
}
