using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command
{
    public class NewUsuarioHistoricoEscolarRequestCommand : IRequest<ResponseVo>
    {
        public int IdHistoricoEscolar { get; set; }
        public int IdUsuario { get; set; }

    }
}
