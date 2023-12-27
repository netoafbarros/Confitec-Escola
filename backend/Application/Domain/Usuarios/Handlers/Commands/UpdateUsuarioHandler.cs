using ConfitecEscola.Application.Domain.Usuarios.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Mapper;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Usuarios.Handlers.Commands
{
    public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IUsuarioRepository _usuarioRepository;

        public UpdateUsuarioHandler(IValidationService validationService,
            IUsuarioRepository repository)
        {
            _validationService = validationService;
            _usuarioRepository = repository;
        }

        public async Task<ResponseVo> Handle(UpdateUsuarioRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                _validationService.Validate(request);

                var entity = ConfitecEscolaMapping.Mapper.Map<Usuario>(request);
                if (entity is null)
                {
                    throw new ApplicationException("Problema no mapeamento");
                }
                await _usuarioRepository.Update(entity);
                response = new ResponseVo(entity, "Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
