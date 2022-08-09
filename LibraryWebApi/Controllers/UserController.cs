using System.Security.Claims;
using Business.Handlers.Users.Commands;
using Business.Handlers.Users.Queries;
using DataAccess.Abstract;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;


public class UserController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet("LogIn")]
    public async Task<IActionResult> GetByUname(string Username, string Password)
    {
        return Ok(await Mediator.Send(new GetLoginUserQuery() {UserName = Username, Password = Password}));
    }
    
    [AllowAnonymous]
    [HttpPost("SignUp")]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        
        return Created("", await Mediator.Send(createUserCommand));
    }

    [HttpGet("userinfo")]
    public async Task<IActionResult> GetUserRole()
    {
        return Ok(await Mediator.Send(new GetUserInfoQuery()));
    }


}