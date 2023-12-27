using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Usuarios.Command
{
    public class ChangeActiveUsuarioRequestCommand : IRequest<ResponseVo>
    {
        public int IdUsuario { get; set; }
        public bool Active { get; set; }
    }
}
