using AutoMapper;
using ConfitecEscola.Application.Domain.Escolaridades.Command;
using ConfitecEscola.Core.Entities;

namespace ConfitecEscola.Application.Mapper.Profilies
{
    public class EscolaridadeMapperProfile : Profile
    {
        public EscolaridadeMapperProfile()
        {
            CreateMap<NewEscolaridadeRequestCommand, Escolaridade>()
                .ForMember(d => d.EscolaridadeDesc,
                    opt => opt.MapFrom(src => src.Escolaridade)
                );

            CreateMap<UpdateEscolaridadeRequestCommand, Escolaridade>()
                .ForMember(d => d.EscolaridadeDesc,
                    opt => opt.MapFrom(src => src.Escolaridade)
                );
        }
    }
}
