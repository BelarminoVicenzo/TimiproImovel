namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIndexOnIdClienteTableImovel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Imovel", new[] { "IdCliente" });
            CreateIndex("dbo.Imovel", "IdCliente");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Imovel", new[] { "IdCliente" });
            CreateIndex("dbo.Imovel", "IdCliente", unique: true);
        }
    }
}
