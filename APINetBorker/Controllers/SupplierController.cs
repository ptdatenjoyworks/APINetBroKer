using AutoMapper;
using Core.Models.Requests.Contract;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APINetBorker.Controllers
{
    [Route("api/supplier")]
    [AllowAnonymous]
    public class SupplierController : ApiControllerBase
    {
        private readonly ISupplierService supplierService;
        private readonly IMapper mapper;


        public SupplierController(ISupplierService supplierService, IMapper mapper)
        {
            this.supplierService = supplierService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await supplierService.GetAll();
            return CreateSuccessResult(suppliers);
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] SupplierRequest supplierRequest)
        {
            await supplierService.Create(supplierRequest);
            return CreateSuccessResult(supplierRequest);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

           var result = await supplierService.Delete(id);

           return CreateSuccessResult(result);
        }


    }
}
