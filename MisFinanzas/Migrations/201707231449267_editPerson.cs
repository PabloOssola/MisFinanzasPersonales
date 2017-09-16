namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "Email", c => c.String());
            DropColumn("dbo.Personas", "Nombre");
            DropColumn("dbo.Personas", "Apellido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personas", "Apellido", c => c.String());
            AddColumn("dbo.Personas", "Nombre", c => c.String());
            DropColumn("dbo.Personas", "Email");
        }
    }
}
