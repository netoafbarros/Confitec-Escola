using ConfitecEscola.Application.Domain.HistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Mapper;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Handlers
{
    public class UpdateUsuarioHistoricoEscolarHandler : IRequestHandler<UpdateUsuarioHistoricoEscolarRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IUsuarioHistoricoEscolarRepository _repository;

        public UpdateUsuarioHistoricoEscolarHandler(IValidationService validationService,
            IUsuarioHistoricoEscolarRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(UpdateUsuarioHistoricoEscolarRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                _validationService.Validate(request);

                var entity = ConfitecEscolaMapping.Mapper.Map<UsuarioHistoricoEscolar>(request);
                if (entity is null)
                {
                    throw new ApplicationException("Problema no mapeamento");
                }
                await _repository.Update(entity);
                response = new ResponseVo(entity, "Usuário Histórico Escolar atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
