using ConfitecEscola.Application.Domain.Usuarios.Queries;
using ConfitecEscola.Application.Domain.VO;
using ConfitecEscola.Core.Repositories;
using MediatR;

namespace ConfitecEscola.Application.Domain.Usuarios.Handlers.Queries
{
    public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosRequestQuery, ResponseVo>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public GetAllUsuariosHandler(IUsuarioRepository repository)
        {
            _usuarioRepository = repository;
        }

        public async Task<ResponseVo> Handle(GetAllUsuariosRequestQuery request, CancellationToken cancellationToken)
        {
            var response = new ResponseVo();

            try
            {
                var list = await _usuarioRepository.GetAllActive();
                response = list != null && list.Count() > 0 ?
                    new ResponseVo(list, "Returnig all active rows") :
                    new ResponseVo(null, "Nenhum usuário existente no banco de dados", true);
            }
            catch (Exception ex)
            {
                response = new ResponseVo(request, ex.Message, true);
            }

            return response;
        }
    }
}
