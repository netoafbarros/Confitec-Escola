using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories.Base;

namespace ConfitecEscola.Core.Repositories
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<IEnumerable<Usuario>> GetAllActive();
        Task<Usuario> GetById(int id);
        Task<IEnumerable<Usuario>> GetByNome(string nome);
        Task<IEnumerable<Usuario>> GetByEscolaridade(int escolaridade);
        Task<Usuario> Add(Usuario entity);
        Task Update(Usuario entity);
        Task Delete(Usuario entity);
    }
}
