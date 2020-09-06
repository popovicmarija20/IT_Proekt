namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regex2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderForms", "Name", c => c.String(nullable: false));
            AddColumn("dbo.OrderForms", "Surname", c => c.String(nullable: false));
            AddColumn("dbo.OrderForms", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderForms", "Address");
            DropColumn("dbo.OrderForms", "Surname");
            DropColumn("dbo.OrderForms", "Name");
        }
    }
}
