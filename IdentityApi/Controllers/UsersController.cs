using Business.Handlers.Books.Queries;
using Business.Handlers.Users.Queries;
using IdentityApi.Controllers.BaseController;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers;


public class UsersController : BaseApiController
{
    
    
    [HttpGet("LogIn")]
    public async Task<IActionResult> GetBy()
    {
        return Ok(await Mediator.Send(new GetBooksQuery()));
    }
}