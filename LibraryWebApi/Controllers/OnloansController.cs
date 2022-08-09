using Business.Handlers.Onloans.Commands;
using Business.Handlers.Onloans.Queries;
using LibraryWebApi.Controllers.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;


public class OnloansController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await Mediator.Send(new GetOnloansQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetOnloanQuery(){OnloanId = id}));
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOnloanCommand createOnloanCommand)
    {
        return Created("" ,await Mediator.Send(createOnloanCommand));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOnloanCommand updateOnloanCommand)
    {
        return Ok(await Mediator.Send(updateOnloanCommand));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteOnloanCommand deleteOnloanCommand)
    {
        return Ok(await Mediator.Send(deleteOnloanCommand));
    }
    
    [HttpGet("onloanofmemberandbook")]
    public async Task<IActionResult> GetOnloanOfMemberAndBook(int onloanId)
    {
        return Ok(await Mediator.Send(new GetOnloanOfMemberAndBookQuery(){OnloanId = onloanId}));
    }
}