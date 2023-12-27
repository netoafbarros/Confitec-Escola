using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Usuarios.Command
{
    public class DeleteUsuarioRequestCommand : IRequest<ResponseVo>
    {
        public int IdUsuario { get; set; }
    }
}
