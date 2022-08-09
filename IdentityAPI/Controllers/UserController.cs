
using Business.Handlers.Users.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BaseApiController = IdentityAPI.Controllers.BaseController.BaseApiController;

namespace IdentityAPI.Controllers;


public class UserController :BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Login(string userName, string password)
    {
        return Ok(await Mediator.Send(new GetLoginUserQuery(){UserName = userName,Password = password}));
    }

    [AllowAnonymous]
    [HttpGet("deneme")]
    public IActionResult login()
    {
        return Ok(new List<string> { "ahmet", "mehmet", "elcabbar" });
    }

    [HttpPost]
    public IActionResult Add()
    {
        return Created("", NoContent());
    }
    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok(NoContent());
    }
    [HttpPut]
    public IActionResult Update()
    {
        return Ok(NoContent());
    }

}
