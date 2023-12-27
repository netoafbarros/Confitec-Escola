using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Queries
{
    public class GetEscolaridadeRequestQuery : IRequest<ResponseVo>
    {
        public int IdEscolaridade { get; set; }
    }
}
