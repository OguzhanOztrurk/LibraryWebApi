using Business.Handlers.Books.Command;
using Business.Handlers.Books.Queries;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetBooksQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetBookQuery(){BookId = id}));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBookCommand createBookCommand)
    {
        return Created("", await Mediator.Send(createBookCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBookCommand updateBookCommand)
    {
        return Ok(await Mediator.Send(updateBookCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteBookCommand deleteBookCommand)
    {
        return Ok(await Mediator.Send(deleteBookCommand));
    }

    [HttpGet("{isbn}/books")]
    public async Task<IActionResult> GetByIsbn(int isbn)
    {
        return Ok(await Mediator.Send(new GetBookIsbnQuery() { IsbnId = isbn }));
    }

    [HttpGet("bookoftypes")]
    public async Task<IActionResult> GetBookOfTypes(int id)
    {
        return Ok(await Mediator.Send(new BookOfTypesQuery() { BookId = id }));
    }
}