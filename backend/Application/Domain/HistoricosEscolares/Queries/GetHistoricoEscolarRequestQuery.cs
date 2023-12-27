using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Queries
{
    public class GetHistoricoEscolarRequestQuery : IRequest<ResponseVo>
    {
        public int IdHistoricoEscolar { get; set; }
    }
}
