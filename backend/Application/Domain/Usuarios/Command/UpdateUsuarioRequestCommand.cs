using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Usuarios.Command
{
    public class UpdateUsuarioRequestCommand : IRequest<ResponseVo>
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdEscolaridade { get; set; }
    }
}
