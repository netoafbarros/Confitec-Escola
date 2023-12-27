using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command
{
    public class UpdateUsuarioHistoricoEscolarRequestCommand : IRequest<ResponseVo>
    {
        public int IdUsuarioHistoricoEscolar { get; set; }
        public int IdHistoricoEscolar { get; set; }
        public int IdUsuario { get; set; }
    }
}
