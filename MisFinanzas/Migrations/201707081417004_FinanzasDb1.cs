namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanzasDb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gastos", "Persona_IdPersona", "dbo.Personas");
            DropIndex("dbo.Gastos", new[] { "Persona_IdPersona" });
            RenameColumn(table: "dbo.Gastos", name: "Persona_IdPersona", newName: "IdPersona");
            AlterColumn("dbo.Gastos", "IdPersona", c => c.Int(nullable: false));
            CreateIndex("dbo.Gastos", "IdPersona");
            AddForeignKey("dbo.Gastos", "IdPersona", "dbo.Personas", "IdPersona", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gastos", "IdPersona", "dbo.Personas");
            DropIndex("dbo.Gastos", new[] { "IdPersona" });
            AlterColumn("dbo.Gastos", "IdPersona", c => c.Int());
            RenameColumn(table: "dbo.Gastos", name: "IdPersona", newName: "Persona_IdPersona");
            CreateIndex("dbo.Gastos", "Persona_IdPersona");
            AddForeignKey("dbo.Gastos", "Persona_IdPersona", "dbo.Personas", "IdPersona");
        }
    }
}
