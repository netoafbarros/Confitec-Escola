using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Handlers
{
    public class DeleteUsuarioHistoricoEscolarHandler : IRequestHandler<DeleteUsuarioHistoricoEscolarRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IUsuarioHistoricoEscolarRepository _repository;

        public DeleteUsuarioHistoricoEscolarHandler(IValidationService validationService,
            IUsuarioHistoricoEscolarRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(DeleteUsuarioHistoricoEscolarRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();
            try
            {
                _validationService.Validate(request);

                var entity = await _repository.GetById(request.IdUsuarioHistoricoEscolar);
                if (entity is null)
                {
                    throw new Exception("Usuário Histórico Escolar não encontrado");
                }

                // Exclusão física 
                await _repository.Delete(entity);
                response = new ResponseVo(entity, "Usuário HistoricoEscolar excluído com sucesso!");
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
