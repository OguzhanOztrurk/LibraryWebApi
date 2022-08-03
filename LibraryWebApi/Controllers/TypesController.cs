using Business.Handlers.Types.Commands;
using Business.Handlers.Types.Queries;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TypesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetTypesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetTypeQuery(){TypeId = id}));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTypeCommand createTypeCommand)
    {
        return Created("", await Mediator.Send(createTypeCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTypeCommand updateTypeCommand)
    {
        return Ok(await Mediator.Send(updateTypeCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteTypeCommand deleteTypeCommand)
    {
        return Ok(await Mediator.Send(deleteTypeCommand));
    }

    [HttpGet("typewithbook")]
    public async Task<IActionResult> GetTypeWithBooks(int typeId)
    {
        return Ok(await Mediator.Send(new GetTypeWithBooksQuery(){TypeId = typeId}));
    }
}