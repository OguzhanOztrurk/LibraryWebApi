using IdentityAPI.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAPI.Controllers;

public class DenemeController : BaseApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new List<string> { "sadad", "sdasdaasd" });
    }
}