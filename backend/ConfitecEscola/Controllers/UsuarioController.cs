using ConfitecEscola.Application.Domain.Usuarios.Command;
using ConfitecEscola.Application.Domain.Usuarios.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecEscola.API.Controllers
{
    [EnableCors("AllowEverything")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        public UsuarioController(
            ILogger<UsuarioController> logger,
            IMediator mediator,
            IUsuarioRepository repository)
        {
            _logger = logger;
            _mediator = mediator;
            _repository = repository;
        }

        [EnableCors("AllowEverything")]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var response = new ResponseVo(await _repository.GetAll(), "Returnig all rows");
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllUsuariosRequestQuery());
            if (response != null)
            {
                return !response.HasError ?
                    Ok(response) :
                    ValidationProblem(new ValidationProblemDetails()
                    {
                        Detail = response.Message
                    });
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "idUsuario")] int idUsuario )
        {
            var command = new GetUsuariosRequestQuery() { IdUsuario = idUsuario };
            var response = await _mediator.Send(command);
            if (response != null)
            {
                return !response.HasError ?
                    Ok(response) :
                    ValidationProblem(new ValidationProblemDetails()
                    {
                        Detail = response.Message
                    });
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("New")]
        public async Task<IActionResult> NewUsuario(NewUsuarioRequestCommand command)
        {
            var response = await _mediator.Send(command);
            if (response != null)
            {
                return !response.HasError ?
                    Ok(response) :
                    ValidationProblem( new ValidationProblemDetails() {
                        Detail = response.Message
                    });
            }
            return BadRequest();
        }
        

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdUsuario(UpdateUsuarioRequestCommand command)
        {
            var response = await _mediator.Send(command);
            if (response != null)
            {
                return !response.HasError ?
                    Ok(response) :
                    ValidationProblem(new ValidationProblemDetails()
                    {
                        Detail = response.Message
                    });
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DelUsuario([FromQuery(Name = "idUsuario")] int idUsuario)
        {
            var command = new DeleteUsuarioRequestCommand() { IdUsuario = idUsuario };
            var response = await _mediator.Send(command);
            if (response != null)
            {
                return !response.HasError ?
                    Ok(response) :
                    ValidationProblem(new ValidationProblemDetails()
                    {
                        Detail = response.Message
                    });
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("ChangeActive")]
        public async Task<IActionResult> ChangeActiveUsuario(ChangeActiveUsuarioRequestCommand command)
        {
            var response = await _mediator.Send(command);
            if (response != null)
            {
                return !response.HasError ?
                    Ok(response) :
                    ValidationProblem(new ValidationProblemDetails()
                    {
                        Detail = response.Message
                    });
            }
            return BadRequest();
        }

    }
}
