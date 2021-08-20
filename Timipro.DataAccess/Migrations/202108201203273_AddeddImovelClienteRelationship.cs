namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddeddImovelClienteRelationship : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Imovel", "IdCliente", unique: true);
            AddForeignKey("dbo.Imovel", "IdCliente", "dbo.Cliente", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imovel", "IdCliente", "dbo.Cliente");
            DropIndex("dbo.Imovel", new[] { "IdCliente" });
        }
    }
}
