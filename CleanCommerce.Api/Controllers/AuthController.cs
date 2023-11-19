using CleanCommerce.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using FluentResults;
using CleanCommerce.Application.Authentication.Common;
using MediatR;
using CleanCommerce.Application.Authentication.Commands.Register;
using CleanCommerce.Application.Authentication.Queries.Login;
using MapsterMapper;
using CleanCommerce.Application.Common.Errors;
using Microsoft.AspNetCore.Authorization;

namespace CleanCommerce.Api.Controllers
{
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            Result<AuthenticationResult> authResult = await _mediator.Send(command);

            if (authResult.IsFailed)
            {
                return Problem(authResult.Errors);
            }

            return Ok(_mapper.Map<AuthenticationResponse>(authResult.Value));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);

            Result<AuthenticationResult> authResult = await _mediator.Send(command);

            if (authResult.IsFailed)
            {
                return Problem(authResult.Errors);
            }

            return Ok(_mapper.Map<AuthenticationResponse>(authResult.Value));
        }
    }
}
