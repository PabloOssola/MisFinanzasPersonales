namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addporcentajes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Porcentaje",
                c => new
                    {
                        IdPorcentaje = c.Int(nullable: false, identity: true),
                        Obligatorio = c.Int(nullable: false),
                        Deseoso = c.Int(nullable: false),
                        Inversion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPorcentaje);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Porcentaje");
        }
    }
}
