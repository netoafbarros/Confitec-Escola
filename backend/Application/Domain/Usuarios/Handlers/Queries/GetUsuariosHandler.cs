using ConfitecEscola.Application.Domain.Usuarios.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Application.Services;
using ConfitecEscola.Core.Repositories;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ConfitecEscola.Application.Domain.Usuarios.Handlers.Queries
{
    public class GetUsuariosHandler : IRequestHandler<GetUsuariosRequestQuery, ResponseVo>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IValidationService _validationService;
        public GetUsuariosHandler(IUsuarioRepository repository, IValidationService validator)
        {
            _usuarioRepository = repository;
            _validationService = validator;
        }

        public async Task<ResponseVo> Handle(GetUsuariosRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                _validationService.Validate(request);
                var resp = await _usuarioRepository.GetById(request.IdUsuario);
                response = resp != null ?
                    new ResponseVo(resp, "Row retrieved") :
                    new ResponseVo(null, "Nenhum usuário encontrado no banco de dados", true);
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
