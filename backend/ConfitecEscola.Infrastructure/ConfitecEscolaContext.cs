using ConfitecEscola.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ConfitecEscola.Infrastructure
{
    public class ConfitecEscolaContext : DbContext
    {
        public ConfitecEscolaContext(DbContextOptions<ConfitecEscolaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(p => new { p.IdEscolaridade })
                .IsUnique(true);

            modelBuilder.Entity<Escolaridade>()
                .HasIndex(p => new { p.IdEscolaridade })
                .IsUnique(true);

            modelBuilder.Entity<HistoricoEscolar>()
                .HasIndex(p => new { p.IdHistoricoEscolar })
                .IsUnique(true);

            modelBuilder.Entity<UsuarioHistoricoEscolar>()
                .HasIndex(p => new { p.IdUsuarioHistoricoEscolar })
                .IsUnique(true);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Escolaridade> Escolaridades { get; set; }
        public DbSet<HistoricoEscolar> HistoricosEscolares { get; set; }
        public DbSet<UsuarioHistoricoEscolar> UsuariosHistoricosEscolares { get; set; }
    }
}

