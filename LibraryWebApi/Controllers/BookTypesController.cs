using Business.Handlers.BookTypes.Commands;
using Business.Handlers.BookTypes.Queries;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookTypesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetBookTypesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int typeId,int bookId)
    {
        return Ok(await Mediator.Send(new GetBookTypeQuery(){TypeId = typeId, BookId = bookId}));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookTypeCommand createBookTypeCommand)
    {
        return Created("", await Mediator.Send(createBookTypeCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBookTypeCommand deleteBookTypeCommand)
    {
        return Ok(await Mediator.Send(deleteBookTypeCommand));
    }
}