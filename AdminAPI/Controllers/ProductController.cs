using AdminAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminAPI.Controllers;


public class ProductController : BaseApiController
{
    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new List<string> { "deneme", "deneme2", "deneme3", "deneme4" });
    }
}