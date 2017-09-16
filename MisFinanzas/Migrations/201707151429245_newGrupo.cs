namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newGrupo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        IdGrupo = c.Int(nullable: false, identity: true),
                        Descripion = c.String(),
                    })
                .PrimaryKey(t => t.IdGrupo);
            
            AddColumn("dbo.Personas", "IdGrupo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personas", "IdGrupo");
            DropTable("dbo.Grupos");
        }
    }
}
