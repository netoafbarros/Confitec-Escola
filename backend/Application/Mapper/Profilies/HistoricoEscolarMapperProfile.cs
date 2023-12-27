using AutoMapper;
using ConfitecEscola.Application.Domain.HistoricosEscolares.Command;
using ConfitecEscola.Core.Entities;

namespace ConfitecEscola.Application.Mapper.Profilies
{
    public class HistoricoEscolarMapperProfile : Profile
    {
        public HistoricoEscolarMapperProfile()
        {
            CreateMap<NewHistoricoEscolarRequestCommand, HistoricoEscolar>();

            CreateMap<UpdateHistoricoEscolarRequestCommand, HistoricoEscolar>();
        }
    }
}
