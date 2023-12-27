using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Mapper;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Handlers
{
    public class UpdateEscolaridadeHandler : IRequestHandler<UpdateEscolaridadeRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IEscolaridadeRepository _repository;

        public UpdateEscolaridadeHandler(IValidationService validationService,
            IEscolaridadeRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(UpdateEscolaridadeRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                _validationService.Validate(request);

                var entity = ConfitecEscolaMapping.Mapper.Map<Escolaridade>(request);
                if (entity is null)
                {
                    throw new ApplicationException("Problema no mapeamento");
                }
                await _repository.Update(entity);
                response = new ResponseVo(entity, "Escolaridade atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
