using AutoMapper;
using ConfitecEscola.Application.Domain.UsuarioHistoricosEscolares.Command;
using ConfitecEscola.Core.Entities;

namespace ConfitecEscola.Application.Mapper.Profilies
{
    public class UsuarioHistoricoEscolarMapperProfile : Profile
    {
        public UsuarioHistoricoEscolarMapperProfile()
        {
            CreateMap<NewUsuarioHistoricoEscolarRequestCommand, UsuarioHistoricoEscolar>();

            CreateMap<UpdateUsuarioHistoricoEscolarRequestCommand, UsuarioHistoricoEscolar>();
        }
    }
}
