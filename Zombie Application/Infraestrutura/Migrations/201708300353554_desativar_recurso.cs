namespace Infraestrutura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class desativar_recurso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recursos", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recursos", "isActive");
        }
    }
}
