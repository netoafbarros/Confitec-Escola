using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Handlers.Commands
{
    public class ChangeActiveEscolaridadeHandler : IRequestHandler<ChangeActiveEscolaridadeRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IEscolaridadeRepository _repository;

        public ChangeActiveEscolaridadeHandler(IValidationService validationService,
            IEscolaridadeRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(ChangeActiveEscolaridadeRequestCommand request, CancellationToken cancellationToken)
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

                // Exclusão lógica ( Ativo = 0 )
                entity.Ativo = request.Active;
                await _repository.Update(entity);
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
