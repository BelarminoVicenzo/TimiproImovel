namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CPF = c.String(maxLength: 11),
                        Nome = c.String(nullable: false),
                        Email = c.String(nullable: false, maxLength: 80),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.ClienteImovel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        IdImovel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Imovel", t => t.IdImovel, cascadeDelete: true)
                .ForeignKey("dbo.Cliente", t => t.IdCliente, cascadeDelete: true)
                .Index(t => t.IdCliente)
                .Index(t => t.IdImovel);
            
            CreateTable(
                "dbo.Imovel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Valor = c.Single(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                        IdTipoNegocio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoNegocio", t => t.IdTipoNegocio, cascadeDelete: true)
                .Index(t => t.IdTipoNegocio);
            
            CreateTable(
                "dbo.TipoNegocio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClienteImovel", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.ClienteImovel", "IdImovel", "dbo.Imovel");
            DropForeignKey("dbo.Imovel", "IdTipoNegocio", "dbo.TipoNegocio");
            DropIndex("dbo.Imovel", new[] { "IdTipoNegocio" });
            DropIndex("dbo.ClienteImovel", new[] { "IdImovel" });
            DropIndex("dbo.ClienteImovel", new[] { "IdCliente" });
            DropIndex("dbo.Cliente", new[] { "Email" });
            DropTable("dbo.TipoNegocio");
            DropTable("dbo.Imovel");
            DropTable("dbo.ClienteImovel");
            DropTable("dbo.Cliente");
        }
    }
}
