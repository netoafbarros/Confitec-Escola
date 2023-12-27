using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.Escolaridades.Queries;
using ConfitecEscola.Application.Domain.HistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.HistoricosEscolares.Queries;
using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ConfitecEscola.API.Controllers
{
    [EnableCors("AllowEverything")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioHistoricoEscolarController : ControllerBase
    {
        private readonly ILogger<UsuarioHistoricoEscolarController> _logger;
        private readonly IMediator _mediator;
        private readonly IUsuarioHistoricoEscolarRepository _repository;
        public UsuarioHistoricoEscolarController(
            ILogger<UsuarioHistoricoEscolarController> logger,
            IMediator mediator,
            IUsuarioHistoricoEscolarRepository repository)
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
        [Route("GetById")]
        public async Task<IActionResult> GetById([FromQuery(Name = "IdUsuarioHistoricoEscolar")] int idUsuarioHistoricoEscolar)
        {
            var command = new GetUsuarioHistoricoEscolarRequestQuery() { IdUsuarioHistoricoEscolar = idUsuarioHistoricoEscolar };
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
        public async Task<IActionResult> NewUsuarioHistoricoEscolar(NewUsuarioHistoricoEscolarRequestCommand command)
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
        public async Task<IActionResult> UpdUsuarioHistoricoEscolar(UpdateUsuarioHistoricoEscolarRequestCommand command)
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
        public async Task<IActionResult> DelUsuarioHistoricoEscolar([FromQuery(Name = "idUsuarioHistoricoEscolar")] int idUsuarioHistoricoEscolar)
        {
            var command = new DeleteUsuarioHistoricoEscolarRequestCommand() { IdUsuarioHistoricoEscolar = idUsuarioHistoricoEscolar };
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
