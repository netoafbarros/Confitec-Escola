using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command
{
    public class DeleteUsuarioHistoricoEscolarRequestCommand : IRequest<ResponseVo>
    {
        public int IdUsuarioHistoricoEscolar { get; set; }
    }
}
