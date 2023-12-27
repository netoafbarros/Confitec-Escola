using ConfitecEscola.Application.Domain.HistoricosEscolares.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Handlers
{
    public class GetAllHistoricoEscolarHandler : IRequestHandler<GetAllHistoricoEscolarRequestQuery, ResponseVo>
    {
        private readonly IHistoricoEscolarRepository _repository;

        public GetAllHistoricoEscolarHandler(IHistoricoEscolarRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(GetAllHistoricoEscolarRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                var list = await _repository.GetAllActive();
                response = list != null && list.Count() > 0 ?
                    new ResponseVo(list, "Returnig all active rows") :
                    new ResponseVo(null, "Nenhum Histórico Escolar existente no banco de dados", true);
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
