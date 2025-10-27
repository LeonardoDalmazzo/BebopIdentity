using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identityAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Prioridade> Prioridades { get; set; }
        public DbSet<StatusChamado> StatusChamados { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Chamado> Chamados { get; set; }
        public DbSet<ChamadoHistorico> ChamadoHistorico { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Identity (SEMPRE PRIMEIRO)
            base.OnModelCreating(builder);

            // --- Empresa ---
            builder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.IdEmpresa).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.DataCriacao).HasDefaultValueSql("now()");

                // Empresa -> Usuários
                entity.HasMany(e => e.ApplicationUsers)
                      .WithOne(u => u.Empresa)
                      .HasForeignKey(u => u.IdEmpresa)
                      .OnDelete(DeleteBehavior.SetNull);

                // Empresa -> Chamados (NOVO)
                entity.HasMany(e => e.Chamados)
                      .WithOne(c => c.Empresa)
                      .HasForeignKey(c => c.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict); // Não deixa excluir empresa com chamados
            });

            // --- Setor ---
            builder.Entity<Setor>(entity =>
            {
                entity.Property(s => s.IdSetor).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(s => s.DataCriacao).HasDefaultValueSql("now()");

                // Setor -> Empresa
                entity.HasOne(s => s.Empresa)
                      .WithMany(e => e.Setores)
                      .HasForeignKey(s => s.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict);

                // Setor -> Usuários
                entity.HasMany(s => s.ApplicationUsers)
                      .WithOne(u => u.Setor)
                      .HasForeignKey(u => u.IdSetor)
                      .OnDelete(DeleteBehavior.SetNull);

                // Setor -> Chamados (NOVO)
                entity.HasMany(s => s.Chamados)
                      .WithOne(c => c.Setor)
                      .HasForeignKey(c => c.IdSetor)
                      .OnDelete(DeleteBehavior.SetNull); // Se setor for excluído, chamado perde o vínculo
            });

            // --- Categoria ---
            builder.Entity<Categoria>(entity =>
            {
                entity.Property(c => c.IdCategoria).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(c => c.DataCriacao).HasDefaultValueSql("now()");

                // Categoria -> Chamados (NOVO)
                entity.HasMany(cat => cat.Chamados)
                      .WithOne(c => c.Categoria)
                      .HasForeignKey(c => c.IdCategoria)
                      .OnDelete(DeleteBehavior.Restrict); // Não deixa excluir categoria com chamados
            });

            // --- Prioridade ---
            builder.Entity<Prioridade>(entity =>
            {
                entity.Property(p => p.IdPrioridade).HasDefaultValueSql("gen_random_uuid()");

                // Prioridade -> Chamados (NOVO)
                entity.HasMany(p => p.Chamados)
                      .WithOne(c => c.Prioridade)
                      .HasForeignKey(c => c.IdPrioridade)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- StatusChamado ---
            builder.Entity<StatusChamado>(entity =>
            {
                entity.Property(s => s.IdStatus).HasDefaultValueSql("gen_random_uuid()");

                // Status -> Chamados (NOVO)
                entity.HasMany(s => s.Chamados)
                      .WithOne(c => c.Status)
                      .HasForeignKey(c => c.IdStatus)
                      .OnDelete(DeleteBehavior.Restrict);

                // Status -> Historico (como EraStatus) (NOVO)
                entity.HasMany(s => s.HistoricosComoAnterior)
                      .WithOne(h => h.StatusAnterior)
                      .HasForeignKey(h => h.EraStatusId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Status -> Historico (como NovoStatus) (NOVO)
                entity.HasMany(s => s.HistoricosComoNovo)
                      .WithOne(h => h.StatusNovo)
                      .HasForeignKey(h => h.NovoStatusId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- FAQ ---
            builder.Entity<FAQ>(entity =>
            {
                entity.Property(f => f.IdFAQ).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(f => f.DataCriacao).HasDefaultValueSql("now()");

                entity.HasOne(f => f.Categoria)
                      .WithMany(c => c.FAQs)
                      .HasForeignKey(f => f.IdCategoria)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // --- NOVO: Chamado ---
            builder.Entity<Chamado>(entity =>
            {
                entity.Property(c => c.IdChamado).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(c => c.DataAbertura).HasDefaultValueSql("now()");

                // Relações N-1
                entity.HasOne(c => c.Solicitante)
                      .WithMany(u => u.ChamadosSolicitados)
                      .HasForeignKey(c => c.IdSolicitante)
                      .OnDelete(DeleteBehavior.Restrict); // Não deixa excluir usuário com chamados abertos

                entity.HasOne(c => c.Atendente)
                      .WithMany(u => u.ChamadosAtendidos)
                      .HasForeignKey(c => c.IdAtendente)
                      .OnDelete(DeleteBehavior.SetNull); // Se atendente for excluído, chamado perde o vínculo

                // Outras relações N-1 já configuradas nas entidades pai
            });

            // --- NOVO: ChamadoHistorico ---
            builder.Entity<ChamadoHistorico>(entity =>
            {
                entity.Property(h => h.IdHistorico).HasDefaultValueSql("gen_random_uuid()");
                entity.Property(h => h.DataComentario).HasDefaultValueSql("now()");

                // Histórico -> Chamado
                entity.HasOne(h => h.Chamado)
                      .WithMany(c => c.Historico)
                      .HasForeignKey(h => h.IdChamado)
                      .OnDelete(DeleteBehavior.Cascade); // Se chamado for excluído, histórico vai junto

                // Histórico -> Usuário
                entity.HasOne(h => h.Usuario)
                      .WithMany(u => u.Historicos)
                      .HasForeignKey(h => h.IdUsuario)
                      .OnDelete(DeleteBehavior.Restrict); // Não deixa excluir usuário com histórico

                // Relações com Status já configuradas em StatusChamado
            });
        }
    }
}