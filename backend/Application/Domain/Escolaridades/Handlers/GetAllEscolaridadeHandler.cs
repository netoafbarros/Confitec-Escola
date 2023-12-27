using ConfitecEscola.Application.Domain.Escolaridades.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Handlers
{
    public class GetAllEscolaridadeHandler : IRequestHandler<GetAllEscolaridadeRequestQuery, ResponseVo>
    {
        private readonly IEscolaridadeRepository _repository;

        public GetAllEscolaridadeHandler(IEscolaridadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(GetAllEscolaridadeRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                var list = await _repository.GetAllActive();
                response = list != null && list.Count() > 0 ?
                    new ResponseVo(list, "Returnig all active rows") :
                    new ResponseVo(null, "Nenhuma escolaridade existente no banco de dados", true);
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
