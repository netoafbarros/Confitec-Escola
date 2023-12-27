using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Command
{
    public class UpdateHistoricoEscolarRequestCommand : IRequest<ResponseVo>
    {
        public int IdHistoricoEscolar { get; set; }
        public string Formato { get; set; }
        public string Nome { get; set; }
        public byte[] Arquivo { get; set; }
    }
}
