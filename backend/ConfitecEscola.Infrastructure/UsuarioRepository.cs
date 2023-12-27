using ConfitecEscola.Core.Entities;
using ConfitecEscola.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfitecEscola.Infrastructure
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ConfitecEscolaContext userContext) : base(userContext)
        {
        }
        public async Task<IEnumerable<Usuario>> GetAll() => await this.GetAllAsync();

        public async Task<IEnumerable<Usuario>> GetAllActive()
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.Ativo == true).ToList();
        }

        public async Task<IEnumerable<Usuario>> GetByEscolaridade(int idEscolaridade)
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.IdEscolaridade == idEscolaridade).ToList();
        }

        public async Task<Usuario> GetById(int id) => await this.GetByIdAsync(id);

        public async Task<IEnumerable<Usuario>> GetByNome(string nome)
        {
            var list = await this.GetAllAsync();
            return list.Where(u => u.Nome.ToUpperInvariant().StartsWith(nome.ToUpperInvariant())).ToList();
        }
        public Task<Usuario> Add(Usuario entity) => this.AddAsync(entity);

        public Task Update(Usuario entity) => this.UpdateAsync(entity);

        public Task Delete(Usuario entity) => this.DeleteAsync(entity);
    }
}
