namespace INVENTARIO.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        usuarioId = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(),
                        apellido = c.String(),
                        direccion = c.String(),
                        telefono = c.Int(nullable: false),
                        perfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.usuarioId)
                .ForeignKey("dbo.Perfil", t => t.perfilId)
                .Index(t => t.perfilId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "perfilId", "dbo.Perfil");
            DropIndex("dbo.Usuario", new[] { "perfilId" });
            DropTable("dbo.Usuario");
        }
    }
}
