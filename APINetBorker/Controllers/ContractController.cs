using AutoMapper;
using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;
using Core.Services.Contracts;
using Domain.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APINetBorker.Controllers
{
    [Route("api/contract")]
    [AllowAnonymous]
    public class ContractController : ApiControllerBase
    {
        private readonly IContractService contractService;
        private readonly IMapper mapper;

        public ContractController(IContractService contractService, IMapper mapper)
        {
            this.contractService = contractService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await contractService.GetAll();
            return CreateSuccessResult(contracts);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] ContractRequest contractRequest)
        {
            var result = await contractService.Create(contractRequest);
            return result != null ? CreateSuccessResult(contractRequest) : CreateFailResult("Contract not Active");
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await contractService.Delete(id);

            return CreateSuccessResult(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] ContractRequest contractRequest)
        {
            var result = contractService.Update(contractRequest);
            return CreateSuccessResult(result);
        }
    }
}
