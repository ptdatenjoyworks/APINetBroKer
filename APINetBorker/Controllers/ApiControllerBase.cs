using Core.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace APINetBorker.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult CreateSuccessResult<T>(T result)
        {
            return Ok(new ActionResponse<T>(result));
        }

        protected IActionResult CreateSuccess()
        {
            return Ok(new ActionResponse());
        }

        protected IActionResult CreateFailResult(string error)
        {
            return this.Ok(new FailActionResponse(error));
        }

        protected IActionResult CreateFailResult(string error, int errorCode)
        {
            return this.Ok(new FailActionResponse(error, errorCode));
        }

        protected IActionResult CreateModelStateErrors(ModelStateDictionary modelState)
        {
            return this.Ok(new ModelStateError("The request is invalid.", modelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))));
        }
    }
}
