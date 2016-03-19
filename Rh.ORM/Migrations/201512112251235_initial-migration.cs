namespace Rh.ORM.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        CandidatoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 200, unicode: false),
                        Email = c.String(maxLength: 200, unicode: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Telefone = c.String(maxLength: 14, unicode: false),
                        Celular = c.String(maxLength: 14, unicode: false),
                        CidadeId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CandidatoId)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Estado", t => t.EstadoId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Entrevista",
                c => new
                    {
                        EntrevistaId = c.Int(nullable: false, identity: true),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comentario = c.String(maxLength: 100000, unicode: false),
                        DataEntrevista = c.DateTime(nullable: false),
                        VagaId = c.Int(nullable: false),
                        CandidatoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EntrevistaId)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId)
                .ForeignKey("dbo.Vaga", t => t.VagaId)
                .Index(t => t.VagaId)
                .Index(t => t.CandidatoId);
            
            CreateTable(
                "dbo.Vaga",
                c => new
                    {
                        VagaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 1000, unicode: false),
                        Descricao = c.String(maxLength: 100000, unicode: false),
                        Situacao = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VagaId);
            
            CreateTable(
                "dbo.Formacao",
                c => new
                    {
                        FormacaoId = c.Int(nullable: false, identity: true),
                        Curso = c.String(maxLength: 500, unicode: false),
                        Instituicao = c.String(maxLength: 1000, unicode: false),
                        Descricao = c.String(maxLength: 100000, unicode: false),
                        Conclusao = c.DateTime(nullable: false),
                        CadidatoId = c.Int(nullable: false),
                        Candidato_CandidatoId = c.Int(),
                    })
                .PrimaryKey(t => t.FormacaoId)
                .ForeignKey("dbo.Candidato", t => t.Candidato_CandidatoId)
                .Index(t => t.Candidato_CandidatoId);
            
            CreateTable(
                "dbo.Tecnologia",
                c => new
                    {
                        TecnologiaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 1000, unicode: false),
                        Descricao = c.String(maxLength: 100000, unicode: false),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.TecnologiaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Formacao", "Candidato_CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.Entrevista", "VagaId", "dbo.Vaga");
            DropForeignKey("dbo.Entrevista", "CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.Candidato", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "EstadoId", "dbo.Estado");
            DropIndex("dbo.Formacao", new[] { "Candidato_CandidatoId" });
            DropIndex("dbo.Entrevista", new[] { "CandidatoId" });
            DropIndex("dbo.Entrevista", new[] { "VagaId" });
            DropIndex("dbo.Cidade", new[] { "EstadoId" });
            DropIndex("dbo.Candidato", new[] { "CidadeId" });
            DropTable("dbo.Tecnologia");
            DropTable("dbo.Formacao");
            DropTable("dbo.Vaga");
            DropTable("dbo.Entrevista");
            DropTable("dbo.Estado");
            DropTable("dbo.Cidade");
            DropTable("dbo.Candidato");
        }
    }
}
