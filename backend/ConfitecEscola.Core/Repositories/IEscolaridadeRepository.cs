using ConfitecEscola.Core.Entities;

namespace ConfitecEscola.Core.Repositories
{
    public interface IEscolaridadeRepository
    {
        Task<IEnumerable<Escolaridade>> GetAll();
        Task<IEnumerable<Escolaridade>> GetAllActive();
        Task<Escolaridade> GetById(int id);
        Task<IEnumerable<Escolaridade>> GetByEscolaridade(string escolaridade);
        Task<Escolaridade> Add(Escolaridade entity);
        Task Update(Escolaridade entity);
        Task Delete(Escolaridade entity);
    }
}
