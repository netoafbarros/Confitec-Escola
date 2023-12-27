using ConfitecEscola.Application.Domain.HistoricosEscolares.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Handlers
{
    public class GetHistoricoEscolarHandler : IRequestHandler<GetHistoricoEscolarRequestQuery, ResponseVo>
    {
        private readonly IHistoricoEscolarRepository _repository;
        private readonly IValidationService _validationService;
        public GetHistoricoEscolarHandler(IHistoricoEscolarRepository repository, IValidationService validationService)
        {
            _repository = repository;
            _validationService = validationService;
        }

        public async Task<ResponseVo> Handle(GetHistoricoEscolarRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();
            try
            {
                _validationService.Validate(request);
                var resp = await _repository.GetById(request.IdHistoricoEscolar);
                response = resp != null ?
                    new ResponseVo(resp, "Row retrieved") :
                    new ResponseVo(null, "Nenhum Histórico Escolar encontrado no banco de dados", true);
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
