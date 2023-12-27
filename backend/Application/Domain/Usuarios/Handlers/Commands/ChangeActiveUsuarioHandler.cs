using ConfitecEscola.Application.Domain.Usuarios.Command;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Usuarios.Handlers.Commands
{
    public class ChangeActiveUsuarioHandler : IRequestHandler<ChangeActiveUsuarioRequestCommand, ResponseVo>
    {
        private readonly IValidationService _validationService;
        private readonly IUsuarioRepository _usuarioRepository;

        public ChangeActiveUsuarioHandler(IValidationService validationService,
            IUsuarioRepository repository)
        {
            _validationService = validationService;
            _usuarioRepository = repository;
        }

        public async Task<ResponseVo> Handle(ChangeActiveUsuarioRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();
            try
            {
                _validationService.Validate(request);

                var entity = await _usuarioRepository.GetById(request.IdUsuario);
                if (entity is null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                // Exclusão lógica ( Ativo = 0 )
                entity.Ativo = request.Active;
                await _usuarioRepository.Update(entity);
                response = new ResponseVo(entity, "Usuário excluído com sucesso!");
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
