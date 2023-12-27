using ConfitecEscola.Application.Domain.HistoricosEscolares.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Mapper;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Handlers
{
    public class NewHistoricoEscolarHandler : IRequestHandler<NewHistoricoEscolarRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IHistoricoEscolarRepository _repository;

        public NewHistoricoEscolarHandler(IValidationService validationService,
            IHistoricoEscolarRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(NewHistoricoEscolarRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                _validationService.Validate(request);

                var entity = ConfitecEscolaMapping.Mapper.Map<HistoricoEscolar>(request);
                if (entity is null)
                {
                    throw new ApplicationException("Problema no mapeamento");
                }
                var newEntity = await _repository.Add(entity);
                if (newEntity != null)
                {
                    response = new ResponseVo(newEntity, "Histórico Escolar cadastrada com sucesso!");
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
