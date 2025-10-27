using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identityAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // DbSets existentes
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Setor> Setores { get; set; }

        // DbSets dos Parâmetros
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Prioridade> Prioridades { get; set; }
        public DbSet<StatusChamado> StatusChamados { get; set; }
        public DbSet<FAQ> FAQs { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Configuração do Identity (SEMPRE PRIMEIRO)
            base.OnModelCreating(builder);

            // --- Configuração da Entidade Empresa ---
            builder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.IdEmpresa)
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(e => e.DataCriacao)
                    .HasDefaultValueSql("now()");

                // NOVA Relação: Empresa -> Usuários
                entity.HasMany(e => e.ApplicationUsers)
                      .WithOne(u => u.Empresa)
                      .HasForeignKey(u => u.IdEmpresa)
                      .OnDelete(DeleteBehavior.SetNull); // Conforme SQL
            });

            // --- Configuração da Entidade Setor ---
            builder.Entity<Setor>(entity =>
            {
                entity.Property(s => s.IdSetor)
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(s => s.DataCriacao)
                    .HasDefaultValueSql("now()");

                // Relação existente: Setor -> Empresa
                entity.HasOne(s => s.Empresa)
                      .WithMany(e => e.Setores)
                      .HasForeignKey(s => s.IdEmpresa)
                      .OnDelete(DeleteBehavior.Restrict);

                // NOVA Relação: Setor -> Usuários
                entity.HasMany(s => s.ApplicationUsers)
                      .WithOne(u => u.Setor)
                      .HasForeignKey(u => u.IdSetor)
                      .OnDelete(DeleteBehavior.SetNull); // Conforme SQL
            });

            // --- Configuração da Entidade Categoria ---
            builder.Entity<Categoria>(entity =>
            {
                entity.Property(c => c.IdCategoria)
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(c => c.DataCriacao)
                    .HasDefaultValueSql("now()");
            });

            // --- Configuração da Entidade Prioridade ---
            builder.Entity<Prioridade>(entity =>
            {
                entity.Property(p => p.IdPrioridade)
                    .HasDefaultValueSql("gen_random_uuid()");
            });

            // --- Configuração da Entidade StatusChamado ---
            builder.Entity<StatusChamado>(entity =>
            {
                entity.Property(s => s.IdStatus)
                    .HasDefaultValueSql("gen_random_uuid()");
            });

            // --- Configuração da Entidade FAQ ---
            builder.Entity<FAQ>(entity =>
            {
                entity.Property(f => f.IdFAQ)
                    .HasDefaultValueSql("gen_random_uuid()");
                entity.Property(f => f.DataCriacao)
                    .HasDefaultValueSql("now()");

                entity.HasOne(f => f.Categoria)
                      .WithMany(c => c.FAQs)
                      .HasForeignKey(f => f.IdCategoria)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}