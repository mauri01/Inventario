namespace INVENTARIO.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassInventario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventario",
                c => new
                    {
                        inventarioId = c.Int(nullable: false, identity: true),
                        producto = c.String(),
                        marca = c.String(),
                        modelo = c.String(),
                        cantidad = c.Int(nullable: false),
                        precio = c.Int(nullable: false),
                        usuarioId = c.Int(nullable: false),
                        usuario_usuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.inventarioId)
                .ForeignKey("dbo.Usuario", t => t.usuario_usuarioId)
                .Index(t => t.usuario_usuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventario", "usuario_usuarioId", "dbo.Usuario");
            DropIndex("dbo.Inventario", new[] { "usuario_usuarioId" });
            DropTable("dbo.Inventario");
        }
    }
}
