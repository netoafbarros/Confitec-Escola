using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Handlers
{
    public class DeleteEscolaridadeHandler : IRequestHandler<DeleteEscolaridadeRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IEscolaridadeRepository _repository;

        public DeleteEscolaridadeHandler(IValidationService validationService,
            IEscolaridadeRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(DeleteEscolaridadeRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();
            try
            {
                _validationService.Validate(request);

                var entity = await _repository.GetById(request.IdEscolaridade);
                if (entity is null)
                {
                    throw new Exception("Escolaridade não encontrada");
                }

                // Exclusãi física 
                await _repository.Delete(entity);
                response = new ResponseVo(entity, "Escolaridade excluída com sucesso!");
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
