namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedStringLengthForNomeAndDescricaoOnTableClienteAndImovel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "Nome", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Imovel", "Descricao", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Imovel", "Descricao", c => c.String());
            AlterColumn("dbo.Cliente", "Nome", c => c.String(nullable: false));
        }
    }
}
