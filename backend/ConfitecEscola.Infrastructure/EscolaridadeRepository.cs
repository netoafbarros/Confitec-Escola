using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;

namespace ConfitecEscola.Infrastructure
{
    public class EscolaridadeRepository : Repository<Escolaridade>, IEscolaridadeRepository
    {
        public EscolaridadeRepository(ConfitecEscolaContext userContext) : base(userContext)
        {
        }
        public async Task<IEnumerable<Escolaridade>> GetAll() => await this.GetAllAsync();

        public async Task<IEnumerable<Escolaridade>> GetAllActive()
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.Ativo == true).ToList();
        }

        public async Task<Escolaridade> GetById(int id) => await this.GetByIdAsync(id);

        public async Task<IEnumerable<Escolaridade>> GetByEscolaridade(string escolaridade)
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.EscolaridadeDesc.ToUpperInvariant().StartsWith(escolaridade.ToUpperInvariant())).ToList();
        }
        public Task<Escolaridade> Add(Escolaridade entity) => this.AddAsync(entity);

        public Task Update(Escolaridade entity) => this.UpdateAsync(entity);

        public Task Delete(Escolaridade entity) => this.DeleteAsync(entity);
    }
}
