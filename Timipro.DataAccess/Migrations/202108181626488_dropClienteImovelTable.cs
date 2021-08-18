namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropClienteImovelTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClienteImovel", "IdImovel", "dbo.Imovel");
            DropForeignKey("dbo.ClienteImovel", "IdCliente", "dbo.Cliente");
            DropIndex("dbo.ClienteImovel", new[] { "IdCliente" });
            DropIndex("dbo.ClienteImovel", new[] { "IdImovel" });
            DropTable("dbo.ClienteImovel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClienteImovel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        IdImovel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ClienteImovel", "IdImovel");
            CreateIndex("dbo.ClienteImovel", "IdCliente");
            AddForeignKey("dbo.ClienteImovel", "IdCliente", "dbo.Cliente", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClienteImovel", "IdImovel", "dbo.Imovel", "Id", cascadeDelete: true);
        }
    }
}
