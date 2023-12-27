using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.Escolaridades.Queries;
using ConfitecEscola.Application.Domain.HistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.HistoricosEscolares.Queries;
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
    public class HistoricoEscolarController : ControllerBase
    {
        private readonly ILogger<HistoricoEscolarController> _logger;
        private readonly IMediator _mediator;
        private readonly IHistoricoEscolarRepository _repository;
        public HistoricoEscolarController(
            ILogger<HistoricoEscolarController> logger,
            IMediator mediator,
            IHistoricoEscolarRepository repository)
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
            var response = await _mediator.Send(new GetAllHistoricoEscolarRequestQuery());
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
        public async Task<IActionResult> GetById([FromQuery(Name = "IdHistoricoEscolar")] int idHistoricoEscolar)
        {
            var command = new GetHistoricoEscolarRequestQuery() { IdHistoricoEscolar = idHistoricoEscolar };
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
        public async Task<IActionResult> NewHistoricoEscolar(NewHistoricoEscolarRequestCommand command)
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

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdHistoricoEscolar(UpdateHistoricoEscolarRequestCommand command)
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
        public async Task<IActionResult> DelHistoricoEscolar([FromQuery(Name = "idHistoricoEscolar")] int idHistoricoEscolar)
        {
            var command = new DeleteHistoricoEscolarRequestCommand() { IdHistoricoEscolar = idHistoricoEscolar };
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
        public async Task<IActionResult> ChangeActiveHistoricoEscolar(ChangeActiveHistoricoEscolarRequestCommand command)
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
