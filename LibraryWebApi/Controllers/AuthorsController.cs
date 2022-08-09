using Business.Handlers.Authors.Commands;
using Business.Handlers.Authors.Queries;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;


public class AuthorsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetAuthersQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetAuthorQuery() { AuthorId = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAuthorCommand createAuthorCommand)
    {
        return Created("", await Mediator.Send(createAuthorCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand updateAuthorCommand)
    {
        return Ok(await Mediator.Send(updateAuthorCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteAuthorCommand deleteAuthorCommand)
    {
        return Ok(await Mediator.Send(deleteAuthorCommand));
    }
    
    [HttpGet("authorofbooks")]
    public async Task<IActionResult> GetAuthorOfBooks(int authorId)
    {
        return Ok(await Mediator.Send(new GetAuthorOfBookQuery(){AuthorId = authorId}));
    }
}