using Business.Handlers.Books.Queries;
using InternalApi.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace InternalApi.Controllers;

public class DenemeController :BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> get()
    {
        return Ok(await Mediator.Send(new GetBooksQuery()));
    }
}