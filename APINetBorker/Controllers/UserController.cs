using AutoMapper;
using Core.Entities.User;
using Core.Models.Requests.User;
using Core.Models.Response.User;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APINetBorker.Controllers
{
    [Route("api/users")]
    [AllowAnonymous]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService userService;
        private readonly IAuthenticationService authenticationService;
        private readonly IMapper mapper;
        private readonly ILoggerManager logger;
        public UserController(IUserService userService, IAuthenticationService authenticationService, IMapper mapper, ILoggerManager logger)
        {
            this.userService = userService;
            this.authenticationService = authenticationService; 
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var user = await userService.GetAll();
            return CreateSuccessResult(mapper.Map<List<User>, List<UserResponse>>(user));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await userService.GetById(id);
            if (user == null)
            {
                return CreateFailResult("User not found.");
            }

            return CreateSuccessResult(mapper.Map<UserResponse>(user));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            var user = await authenticationService.Autheticate(request);
            if (user == null)
            {
                return CreateFailResult("UserName or password is incorrect.");
            }

            var token = await authenticationService.CreateToken(user);

            return CreateSuccessResult(new
            {
                token,
                user = mapper.Map<UserResponse>(user)
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] UserRegisterRequest request)
        {
            var result = await authenticationService.RegisterUser(request);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return CreateModelStateErrors(ModelState);
            }
            return CreateSuccess();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return CreateModelStateErrors(ModelState);
            }

            var user = await userService.GetById(request.Id ?? 0);
            if (user == null)
            {
                return CreateFailResult("User not found.");
            }

            mapper.Map(request, user);
            await userService.Update(user);
            return CreateSuccessResult(mapper.Map<UserResponse>(user));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userService.GetById(id);
            if (user == null)
            {
                return CreateFailResult("User not found.");
            }

            await userService.Delete(id);
            return CreateSuccess();
        }
    }
}
