namespace INVENTARIO.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassUsuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventario", "usuario_usuarioId", "dbo.Usuario");
            DropIndex("dbo.Inventario", new[] { "usuario_usuarioId" });
            DropColumn("dbo.Inventario", "usuarioId");
            RenameColumn(table: "dbo.Inventario", name: "usuario_usuarioId", newName: "usuarioId");
            DropPrimaryKey("dbo.Usuario");
            AlterColumn("dbo.Inventario", "usuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuario", "usuarioId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Usuario", "usuarioId");
            CreateIndex("dbo.Inventario", "usuarioId");
            AddForeignKey("dbo.Inventario", "usuarioId", "dbo.Usuario", "usuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventario", "usuarioId", "dbo.Usuario");
            DropIndex("dbo.Inventario", new[] { "usuarioId" });
            DropPrimaryKey("dbo.Usuario");
            AlterColumn("dbo.Usuario", "usuarioId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Inventario", "usuarioId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Usuario", "usuarioId");
            RenameColumn(table: "dbo.Inventario", name: "usuarioId", newName: "usuario_usuarioId");
            AddColumn("dbo.Inventario", "usuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Inventario", "usuario_usuarioId");
            AddForeignKey("dbo.Inventario", "usuario_usuarioId", "dbo.Usuario", "usuarioId");
        }
    }
}
