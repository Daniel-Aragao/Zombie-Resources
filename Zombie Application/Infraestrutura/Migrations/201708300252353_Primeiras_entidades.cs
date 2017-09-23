namespace Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Primeiras_entidades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movimentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Antes = c.Int(nullable: false),
                        Depois = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
                        TipoMovimento = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        RecursoId = c.Int(nullable: false),
                        ResponsavelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recursos", t => t.RecursoId, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.ResponsavelId, cascadeDelete: true)
                .Index(t => t.RecursoId)
                .Index(t => t.ResponsavelId);
            
            CreateTable(
                "dbo.Recursos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Observacao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimentos", "ResponsavelId", "dbo.Usuarios");
            DropForeignKey("dbo.Movimentos", "RecursoId", "dbo.Recursos");
            DropIndex("dbo.Movimentos", new[] { "ResponsavelId" });
            DropIndex("dbo.Movimentos", new[] { "RecursoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Recursos");
            DropTable("dbo.Movimentos");
        }
    }
}
