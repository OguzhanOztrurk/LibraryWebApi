using Business.Handlers.Members.Commands;
using Business.Handlers.Members.Queries;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;


public class MembersController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetMembersQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetMemberQuery(){MemberId = id}));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMemberCommand createMemberCommand)
    {
        return Created("", await Mediator.Send(createMemberCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMemberCommand updateMemberCommand)
    {
        return Ok(await Mediator.Send(updateMemberCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteMemberCommand deleteMemberCommand)
    {
        return Ok(await Mediator.Send(deleteMemberCommand));
    }
    
    [HttpGet("memberofbook")]
    public async Task<IActionResult> GetMemberOfBook(int memberId)
    {
        return Ok(await Mediator.Send(new GetMemberOfBooksQuery() { MemberId = memberId }));
    }
}