using ConfitecEscola.Core.Entities;

namespace ConfitecEscola.Core.Repositories
{
    public interface IHistoricoEscolarRepository
    {
        Task<IEnumerable<HistoricoEscolar>> GetAll();
        Task<IEnumerable<HistoricoEscolar>> GetAllActive();
        Task<HistoricoEscolar> GetById(int id);
        Task<IEnumerable<HistoricoEscolar>> GetByFormato(string formato);
        Task<IEnumerable<HistoricoEscolar>> GetByNome(string nome);
        Task<HistoricoEscolar> Add(HistoricoEscolar entity);
        Task Update(HistoricoEscolar entity);
        Task Delete(HistoricoEscolar entity);
    }
}
