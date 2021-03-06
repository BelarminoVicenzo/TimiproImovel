namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeinKeyCLienteOnImovel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Imovel", "Id", "dbo.Cliente");
            DropIndex("dbo.Imovel", new[] { "Id" });
            DropPrimaryKey("dbo.Imovel");
            AlterColumn("dbo.Imovel", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Imovel", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Imovel");
            AlterColumn("dbo.Imovel", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Imovel", "Id");
            CreateIndex("dbo.Imovel", "Id");
            AddForeignKey("dbo.Imovel", "Id", "dbo.Cliente", "Id");
        }
    }
}
