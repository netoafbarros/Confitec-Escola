using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Command
{
    public class ChangeActiveHistoricoEscolarRequestCommand : IRequest<ResponseVo>
    {
        public int IdHistoricoEscolar { get; set; }
        public bool Active { get; set; }
    }
}
