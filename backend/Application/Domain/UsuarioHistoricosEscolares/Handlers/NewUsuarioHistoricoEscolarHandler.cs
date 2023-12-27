using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Mapper;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Handlers
{
    public class NewUsuarioHistoricoEscolarHandler : IRequestHandler<NewUsuarioHistoricoEscolarRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IUsuarioHistoricoEscolarRepository _repository;

        public NewUsuarioHistoricoEscolarHandler(IValidationService validationService,
            IUsuarioHistoricoEscolarRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(NewUsuarioHistoricoEscolarRequestCommand request, CancellationToken cancellationToken)
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
                var newEntity = await _repository.Add(entity);
                if (newEntity != null)
                {
                    response = new ResponseVo(newEntity, "Usuário Histórico Escolar cadastrado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
