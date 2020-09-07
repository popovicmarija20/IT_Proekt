namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class igradieeeentremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pizzas", "Ingredient");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pizzas", "Ingredient", c => c.String());
        }
    }
}
