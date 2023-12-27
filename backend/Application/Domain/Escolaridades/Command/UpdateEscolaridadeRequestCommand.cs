using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Command
{
    public class UpdateEscolaridadeRequestCommand : IRequest<ResponseVo>
    {
        public int IdEscolaridade { get; set; }
        public string Escolaridade { get; set; }
    }
}
