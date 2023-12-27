using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Command
{
    public class ChangeActiveEscolaridadeRequestCommand : IRequest<ResponseVo>
    {
        public int IdEscolaridade { get; set; }
        public bool Active { get; set; }
    }
}
