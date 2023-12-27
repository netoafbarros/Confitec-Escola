using AutoMapper;
using ConfitecEscola.Application.Domain.Usuarios.Command;
using ConfitecEscola.Core.Entities;

namespace ConfitecEscola.Application.Mapper.Profilies
{
    public class UsuarioMapperProfile : Profile
    {
        public UsuarioMapperProfile()
        {
            CreateMap<NewUsuarioRequestCommand, Usuario>();

            CreateMap<UpdateUsuarioRequestCommand, Usuario>();

        }
    }
}
