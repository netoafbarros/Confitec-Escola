using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Usuarios.Queries
{
    public class GetUsuariosRequestQuery : IRequest<ResponseVo>
    {
        public int IdUsuario { get; set; }
    }
}
