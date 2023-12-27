using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Queries
{
    public class GetUsuarioHistoricoEscolarRequestQuery : IRequest<ResponseVo>
    {
        public int IdUsuarioHistoricoEscolar { get; set; }
    }
}
