using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Command
{
    public class DeleteHistoricoEscolarRequestCommand : IRequest<ResponseVo>
    {
        public int IdHistoricoEscolar { get; set; }
    }
}
