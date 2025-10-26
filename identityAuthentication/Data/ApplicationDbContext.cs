using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identityAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // NOVO: Adiciona a tabela Empresas ao contexto do banco de dados
        public DbSet<Empresa> Empresas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // NOVO: Adicionado para configurar o mapeamento da nova tabela
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // É essencial chamar base.OnModelCreating() PRIMEIRO 
            // para que as tabelas do Identity sejam configuradas corretamente.
            base.OnModelCreating(builder);

            // Configura a entidade Empresa para corresponder ao Supabase (PostgreSQL)
            // Isso respeita sua regra de "Database First"
            builder.Entity<Empresa>(entity =>
            {
                // Informa ao EF que a coluna IdEmpresa usa gen_random_uuid() no banco
                entity.Property(e => e.IdEmpresa)
                    .HasDefaultValueSql("gen_random_uuid()");

                // Informa ao EF que a coluna DataCriacao usa now() no banco
                entity.Property(e => e.DataCriacao)
                    .HasDefaultValueSql("now()");
            });
        }
    }
}