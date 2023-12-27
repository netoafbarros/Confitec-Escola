using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;

namespace ConfitecEscola.Infrastructure
{
    public class HistoricoEscolarRepository : Repository<HistoricoEscolar>, IHistoricoEscolarRepository
    {
        public HistoricoEscolarRepository(ConfitecEscolaContext userContext) : base(userContext)
        {
        }
        public async Task<IEnumerable<HistoricoEscolar>> GetAll() => await this.GetAllAsync();

        public async Task<IEnumerable<HistoricoEscolar>> GetAllActive()
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.Ativo == true).ToList();
        }

        public async Task<HistoricoEscolar> GetById(int id) => await this.GetByIdAsync(id);

        public async Task<IEnumerable<HistoricoEscolar>> GetByNome(string nome)
        {
            var list = await this.GetByNome(nome);
            return list;
        }

        public async Task<IEnumerable<HistoricoEscolar>> GetByFormato(string formato)
        {
            var list = await this.GetByFormato(formato);
            return list;
        }
        public Task<HistoricoEscolar> Add(HistoricoEscolar entity) => this.AddAsync(entity);

        public Task Update(HistoricoEscolar entity) => this.UpdateAsync(entity);

        public Task Delete(HistoricoEscolar entity) => this.DeleteAsync(entity);
    }
}
