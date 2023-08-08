using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using User.Microservice.Application.Features.User.Commands;
using User.Microservice.Application.Features.User.Queries;
using User.Microservice.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private IApplicationCommandDBContext _context;
        public UserController(IApplicationCommandDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("CreateAllUsers")]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }
        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await Mediator.Send(new GetPostDetailsQuery()));
        }
        [HttpGet]
        [Route("GetUsersByCardType")]
        public async Task<IActionResult> GetUsersByCardType(string _cardType)
        {
            return Ok(await Mediator.Send(new GetUsersByCardTypeQuery() {CardType = _cardType }));
        }
        [HttpGet]
        [Route("GetUsersByPostCount")]
        public async Task<IActionResult> GetUsersByPostCount(int postCount)
        {
            return Ok(await Mediator.Send(new GetUsersByPostCountQuery() { PostCount = postCount }));
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
