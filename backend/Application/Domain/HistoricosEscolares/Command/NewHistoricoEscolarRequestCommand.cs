using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.HistoricosEscolares.Command
{
    public class NewHistoricoEscolarRequestCommand : IRequest<ResponseVo>
    {
        public string Formato { get; set; }
        public string Nome { get; set; }
        public byte[] Arquivo { get; set; }
    }
}
