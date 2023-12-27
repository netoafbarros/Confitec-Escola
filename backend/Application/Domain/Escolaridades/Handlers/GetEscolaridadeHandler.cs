using ConfitecEscola.Application.Domain.Escolaridades.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using ConfitecEscola.Infrastructure;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Handlers
{
    public class GetEscolaridadeHandler : IRequestHandler<GetEscolaridadeRequestQuery, ResponseVo>
    {
        private readonly IEscolaridadeRepository _repository;
        private readonly IValidationService _validationService;
        public GetEscolaridadeHandler(IEscolaridadeRepository repository, IValidationService validationService)
        {
            _repository = repository;
            _validationService = validationService;
        }

        public async Task<ResponseVo> Handle(GetEscolaridadeRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();
            try
            {
                _validationService.Validate(request);
                var resp = await _repository.GetById(request.IdEscolaridade);
                response = resp != null ?
                    new ResponseVo(resp, "Row retrieved") :
                    new ResponseVo(null, "Nenhuma escolaridade encontrada no banco de dados", true);
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
