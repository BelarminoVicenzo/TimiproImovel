namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedImovelClienteRelationship : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Imovel");
            AlterColumn("dbo.Imovel", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Imovel", "Id");
            CreateIndex("dbo.Imovel", "Id");
            AddForeignKey("dbo.Imovel", "Id", "dbo.Cliente", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imovel", "Id", "dbo.Cliente");
            DropIndex("dbo.Imovel", new[] { "Id" });
            DropPrimaryKey("dbo.Imovel");
            AlterColumn("dbo.Imovel", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Imovel", "Id");
        }
    }
}
