using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.Escolaridades.Queries;
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
    public class EscolaridadeController : ControllerBase
    {
        private readonly ILogger<EscolaridadeController> _logger;
        private readonly IMediator _mediator;
        private readonly IEscolaridadeRepository _repository;
        public EscolaridadeController(
            ILogger<EscolaridadeController> logger,
            IMediator mediator,
            IEscolaridadeRepository repository)
        {
            _logger = logger;
            _mediator = mediator;
            _repository = repository;
        }

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
            var response = await _mediator.Send(new GetAllEscolaridadeRequestQuery());
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
        public async Task<IActionResult> GetById([FromQuery(Name = "IdEscolaridade")] int idEscolaridade)
        {
            var command = new GetEscolaridadeRequestQuery() { IdEscolaridade = idEscolaridade };
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
        public async Task<IActionResult> NewEscolaridade(NewEscolaridadeRequestCommand command)
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
        public async Task<IActionResult> UpdUsuario(UpdateEscolaridadeRequestCommand command)
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
        public async Task<IActionResult> DelEscolaridade([FromQuery(Name = "idEscolaridade")] int idEscolaridade)
        {
            var command = new DeleteEscolaridadeRequestCommand() { IdEscolaridade = idEscolaridade };
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
        public async Task<IActionResult> ChangeActiveEscolaridade(ChangeActiveEscolaridadeRequestCommand command)
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
