namespace MisFinanzas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdGrupoGasto : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Gastos", "IdGrupoGasto");
            AddForeignKey("dbo.Gastos", "IdGrupoGasto", "dbo.GrupoGastos", "IdGrupoGasto", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gastos", "IdGrupoGasto", "dbo.GrupoGastos");
            DropIndex("dbo.Gastos", new[] { "IdGrupoGasto" });
        }
    }
}
