using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Handlers
{
    public class GetAllUsuarioHistoricoEscolarHandler : IRequestHandler<GetAllUsuarioHistoricoEscolarRequestQuery, ResponseVo>
    {
        private readonly IUsuarioHistoricoEscolarRepository _repository;

        public GetAllUsuarioHistoricoEscolarHandler(IUsuarioHistoricoEscolarRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(GetAllUsuarioHistoricoEscolarRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                var list = await _repository.GetAll();
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
