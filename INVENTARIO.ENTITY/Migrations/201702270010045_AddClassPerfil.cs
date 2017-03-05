namespace INVENTARIO.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassPerfil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        perfilId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.perfilId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Perfil");
        }
    }
}
