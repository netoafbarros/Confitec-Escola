using ConfitecEscola.Application.Domain.HistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Handlers
{
    public class ChangeActiveHistoricoEscolarHandler : IRequestHandler<ChangeActiveHistoricoEscolarRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IHistoricoEscolarRepository _repository;

        public ChangeActiveHistoricoEscolarHandler(IValidationService validationService,
            IHistoricoEscolarRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(ChangeActiveHistoricoEscolarRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();
            try
            {
                _validationService.Validate(request);

                var entity = await _repository.GetById(request.IdHistoricoEscolar);
                if (entity is null)
                {
                    throw new Exception("Histórico Escolar não encontrado");
                }

                // Exclusão lógica ( Ativo = 0 )
                entity.Ativo = request.Active;
                await _repository.Update(entity);
                response = new ResponseVo(entity, "Histórico Escolar excluído com sucesso!");
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
