namespace INVENTARIO.ENTITY.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClassUsuario1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "email");
        }
    }
}
