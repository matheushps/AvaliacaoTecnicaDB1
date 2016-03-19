using Rh.Dominio;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Rh.ORM
{
  public  class Contexto : DbContext
    {
        /// <summary>
        /// Criando o método construtor do contexto
        /// </summary>
        public Contexto()
            : base("SisRh")
        {

        }

        /// <summary>
        /// Tabelas a serem Criadas no Banco de dados
        /// </summary>
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Entrevista> Entrevistas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Formacao> Formacoes { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }

        /// <summary>
        /// Remover o plural na criação de tabelas do banco de dados
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));
        }

    }
}
