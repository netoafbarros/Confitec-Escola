using AutoMapper;
using ConfitecEscola.Application.Mapper.Profilies;

namespace ConfitecEscola.Application.Mapper
{
    internal class ConfitecEscolaMapping
    {
        
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<UsuarioMapperProfile>();
                cfg.AddProfile<EscolaridadeMapperProfile>();
                cfg.AddProfile<HistoricoEscolarMapperProfile>();
                cfg.AddProfile<UsuarioHistoricoEscolarMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
        
    }
}
