namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanzasDb : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Gastoes", newName: "Gastos");
            RenameTable(name: "dbo.GrupoGastoes", newName: "GrupoGastos");
            AddColumn("dbo.Gastos", "Persona_IdPersona", c => c.Int());
            CreateIndex("dbo.Gastos", "Persona_IdPersona");
            AddForeignKey("dbo.Gastos", "Persona_IdPersona", "dbo.Personas", "IdPersona");
            DropColumn("dbo.Gastos", "IdPersona");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gastos", "IdPersona", c => c.Int(nullable: false));
            DropForeignKey("dbo.Gastos", "Persona_IdPersona", "dbo.Personas");
            DropIndex("dbo.Gastos", new[] { "Persona_IdPersona" });
            DropColumn("dbo.Gastos", "Persona_IdPersona");
            RenameTable(name: "dbo.GrupoGastos", newName: "GrupoGastoes");
            RenameTable(name: "dbo.Gastos", newName: "Gastoes");
        }
    }
}
