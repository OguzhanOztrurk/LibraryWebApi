using Bogus;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternalApi.Controllers.BaseController;

[ApiController]
[Route("Internal/[controller]")]
public class BaseApiController : Controller
{
    private IMediator _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    private static Faker _dg;
    protected static Faker DataGenerator => _dg ??= new Faker(locale: "tr");
}