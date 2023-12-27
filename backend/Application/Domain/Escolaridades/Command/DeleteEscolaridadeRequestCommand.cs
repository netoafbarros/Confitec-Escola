using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Command
{
    public class DeleteEscolaridadeRequestCommand : IRequest<ResponseVo>
    {
        public int IdEscolaridade { get; set; }
    }
}
