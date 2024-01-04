using AutoMapper;
using Core.Models.Requests.Contract;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation.AspNetCore;

namespace APINetBorker.Controllers
{
    [Route("api/contract")]
    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
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
        [PermissionRequirement("admin", "contract:all", "contract:get")]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await contractService.GetAll();
            return CreateSuccessResult(contracts);
        }

        [HttpGet]
        [Route("{id}")]
        [PermissionRequirement("admin", "contract:all", "user:get", "contract:get", "contract-item:get")]
        public async Task<IActionResult> GetContractById(int id)
        {
            var contract = await contractService.FindContractById(id);
            if (contract != null)
            {
                return CreateSuccessResult(contract);
            }
            return CreateFailResult("not found contract");
        }
        [HttpPost]
        [Route("")]
        [PermissionRequirement("admin", "contract:all", "contract:create")]
        public async Task<IActionResult> Create([FromBody] ContractRequest contractRequest)
        {
            var result = await contractService.Create(contractRequest);
            return result != null ? CreateSuccessResult(contractRequest) : CreateFailResult("Contract not Active");
        }

        [HttpDelete]
        [Route("{id}")]
        [PermissionRequirement("admin", "contract:all", "contract:delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await contractService.Delete(id);

            return CreateSuccessResult(result);
        }

        [HttpPost]
        [Route("")]
        [PermissionRequirement("admin", "contract:all", "contract:update")]
        public async Task<IActionResult> Update([FromBody] ContractRequest contractRequest)
        {
            var result = contractService.Update(contractRequest);
            return CreateSuccessResult(result);
        }


    }
}
