namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setidporcentajes : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Porcentaje");
            AlterColumn("dbo.Porcentaje", "IdPorcentaje", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Porcentaje", "IdPorcentaje");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Porcentaje");
            AlterColumn("dbo.Porcentaje", "IdPorcentaje", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Porcentaje", "IdPorcentaje");
        }
    }
}
