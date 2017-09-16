namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gastoes",
                c => new
                    {
                        IdGasto = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdGrupoGasto = c.Int(nullable: false),
                        FechaGasto = c.DateTime(nullable: false),
                        IdPersona = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdGasto);
            
            CreateTable(
                "dbo.GrupoGastoes",
                c => new
                    {
                        IdGrupoGasto = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        TipoGasto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdGrupoGasto);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        IdPersona = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.IdPersona);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Personas");
            DropTable("dbo.GrupoGastoes");
            DropTable("dbo.Gastoes");
        }
    }
}
