using ConfitecEscola.Application.Domain.VO;
using MediatR;

namespace ConfitecEscola.Application.Domain.Escolaridades.Command
{
    public class NewEscolaridadeRequestCommand : IRequest<ResponseVo>
    {
        public string Escolaridade { get; set; }
       
        public bool Ativo { get; set; }
    }
}
