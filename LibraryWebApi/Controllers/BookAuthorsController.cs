using Business.Handlers.BookAuthors.Commands;
using Business.Handlers.BookAuthors.Queries;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookAuthorsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetBookAuthorsQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetBookAuthorQuery(){BookAuthorId = id}));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookAuthorCommand createBookAuthorCommand)
    {
        return Created("", await Mediator.Send(createBookAuthorCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookAuthorCommand updateBookAuthorCommand)
    {
        return Ok(await Mediator.Send(updateBookAuthorCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBookAuthorCommand deleteBookAuthorCommand)
    {
        return Ok(await Mediator.Send(deleteBookAuthorCommand));
    }
}