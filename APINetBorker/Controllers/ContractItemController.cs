using AutoMapper;
using Core.Models.Requests.Contract;
using Core.Services.Contracts;
using Domain.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var result =  await contractItemService.CreateContractItem(contractItemRequest);
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
        public async Task<IActionResult> Update([FromBody] ContractItemRequest contractItemRequest)
        {
            var result = contractItemService.Update(contractItemRequest);
            return CreateSuccessResult(result);
        }
    }
}
