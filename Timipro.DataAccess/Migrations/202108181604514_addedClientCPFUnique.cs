namespace Timipro.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedClientCPFUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cliente", "CPF", c => c.String(nullable: false, maxLength: 11));
            CreateIndex("dbo.Cliente", "CPF", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cliente", new[] { "CPF" });
            AlterColumn("dbo.Cliente", "CPF", c => c.String(maxLength: 11));
        }
    }
}
