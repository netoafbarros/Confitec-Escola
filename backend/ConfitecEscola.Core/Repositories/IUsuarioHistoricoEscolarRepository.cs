using ConfitecEscola.Core.Entities;

namespace ConfitecEscola.Core.Repositories
{
    public interface IUsuarioHistoricoEscolarRepository
    {
        Task<IEnumerable<UsuarioHistoricoEscolar>> GetAll();
        Task<UsuarioHistoricoEscolar> GetById(int id);
        Task<IEnumerable<UsuarioHistoricoEscolar>> GetByUsuario(int idUsuario);
        Task<IEnumerable<UsuarioHistoricoEscolar>> GetByHistoricoEscolar(int idHistoricoEscolar);
        Task<UsuarioHistoricoEscolar> Add(UsuarioHistoricoEscolar entity);
        Task Update(UsuarioHistoricoEscolar entity);
        Task Delete(UsuarioHistoricoEscolar entity);
    }
}
