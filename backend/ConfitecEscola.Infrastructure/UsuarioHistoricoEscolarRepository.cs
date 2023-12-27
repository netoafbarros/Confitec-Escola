using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;

namespace ConfitecEscola.Infrastructure
{
    public class UsuarioHistoricoEscolarRepository : Repository<UsuarioHistoricoEscolar>, IUsuarioHistoricoEscolarRepository
    {
        public UsuarioHistoricoEscolarRepository(ConfitecEscolaContext userContext) : base(userContext)
        {
        }
        public async Task<IEnumerable<UsuarioHistoricoEscolar>> GetAll() => await this.GetAllAsync();

        public async Task<UsuarioHistoricoEscolar> GetById(int id) => await this.GetByIdAsync(id);

        public async Task<IEnumerable<UsuarioHistoricoEscolar>> GetByUsuario(int idUsuario)
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.IdUsuario == idUsuario).ToList();
        }

        public async Task<IEnumerable<UsuarioHistoricoEscolar>> GetByHistoricoEscolar(int idHistorico)
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.IdHistoricoEscolar == idHistorico).ToList();
        }
        public Task<UsuarioHistoricoEscolar> Add(UsuarioHistoricoEscolar entity) => this.AddAsync(entity);

        public Task Update(UsuarioHistoricoEscolar entity) => this.UpdateAsync(entity);

        public Task Delete(UsuarioHistoricoEscolar entity) => this.DeleteAsync(entity);
    }
}
