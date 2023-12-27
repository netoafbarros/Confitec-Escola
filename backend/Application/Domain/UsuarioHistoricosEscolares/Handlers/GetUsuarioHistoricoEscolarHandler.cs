using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Handlers
{
    public class GetUsuarioHistoricoEscolarHandler : IRequestHandler<GetUsuarioHistoricoEscolarRequestQuery, ResponseVo>
    {
        private readonly IUsuarioHistoricoEscolarRepository _repository;
        private readonly IValidationService _validationService;
        public GetUsuarioHistoricoEscolarHandler(IUsuarioHistoricoEscolarRepository repository, IValidationService validationService)
        {
            _repository = repository;
            _validationService = validationService;
        }

        public async Task<ResponseVo> Handle(GetUsuarioHistoricoEscolarRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();
            try
            {
                _validationService.Validate(request);
                var resp = await _repository.GetById(request.IdUsuarioHistoricoEscolar);
                response = resp != null ?
                    new ResponseVo(resp, "Row retrieved") :
                    new ResponseVo(null, "Nenhum Usuário Histórico Escolar encontrado no banco de dados", true);
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
