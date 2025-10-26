using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identityAuthentication.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Setor> Setores { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adicionado para configurar o mapeamento da nova tabela
        // OnModelCreating � onde configuramos as regras do banco de dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // � essencial chamar base.OnModelCreating() PRIMEIRO 
            // para que as tabelas do Identity sejam configuradas corretamente.
            base.OnModelCreating(builder);

            // --- Configura��o da Entidade Empresa ---
            builder.Entity<Empresa>(entity =>
            {
                // Informa ao EF que a coluna IdEmpresa usa gen_random_uuid() no banco
                entity.Property(e => e.IdEmpresa)
                    .HasDefaultValueSql("gen_random_uuid()");

                // Informa ao EF que a coluna DataCriacao usa now() no banco
                entity.Property(e => e.DataCriacao)
                    .HasDefaultValueSql("now()");
            });

            // --- Configura��o da Entidade Setor ---
            builder.Entity<Setor>(entity =>
            {
                // Informa ao EF que o Supabase gera os valores padr�o
                entity.Property(s => s.IdSetor)
                    .HasDefaultValueSql("gen_random_uuid()");

                entity.Property(s => s.DataCriacao)
                    .HasDefaultValueSql("now()");

                // --- Defini��o da Rela��o (Chave Estrangeira) ---

                // Aqui dizemos que:
                // 1. Um Setor (s) TEM UMA Empresa (s.Empresa)
                // 2. Uma Empresa (e) TEM MUITOS Setores (e.Setores)
                // 3. A Chave Estrangeira est� em Setor, na coluna IdEmpresa (s.IdEmpresa)
                entity.HasOne(s => s.Empresa)
                      .WithMany(e => e.Setores)
                      .HasForeignKey(s => s.IdEmpresa)
                      // Impede que voc� exclua uma Empresa se ela ainda tiver Setores ligados a ela.
                      // Voc� teria que excluir os Setores primeiro.
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}