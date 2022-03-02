using Microsoft.AspNetCore.Mvc;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models.Request.User;
using Orders.Domain.Models.Response.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Orders.Api.Controllers
{
    [Route("v1/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticateService _authenticateService;

        #region Constructor
        public UserController(IUserService userService, IAuthenticateService authenticateService)
        {
            _userService = userService;
            _authenticateService = authenticateService;
        }
        #endregion

        #region CreateUser
        [HttpPost]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var obj = await _userService.CreateUser(model);

                return Created(nameof(CreateUser), obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region GetUsers
        [HttpGet]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        //[Authorize(Roles = "manage")]
        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            return await _userService.GetUsers();
        }
        #endregion

        #region Get User by Id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var obj = await _userService.GetUserById(id);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }
        #endregion


        #region Authenticate
        [HttpPost("login")]
        public async Task<dynamic> Authenticate([FromBody] AuthenticateRequest model)
        {
            try
            {
                var auth = await _authenticateService.Authenticate(model);
                return Ok(new
                {
                    token = auth
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
