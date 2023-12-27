using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Mapper;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Handlers.Commands
{
    public class NewEscolaridadeHandler : IRequestHandler<NewEscolaridadeRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IEscolaridadeRepository _repository;

        public NewEscolaridadeHandler(IValidationService validationService,
            IEscolaridadeRepository repository)
        {
            _validationService = validationService;
            _repository = repository;
        }

        public async Task<ResponseVo> Handle(NewEscolaridadeRequestCommand request, CancellationToken cancellationToken)
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
                var newUser = await _repository.Add(entity);
                if (newUser != null)
                {
                    response = new ResponseVo(newUser, "Escolaridade cadastrada com sucesso!");
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
