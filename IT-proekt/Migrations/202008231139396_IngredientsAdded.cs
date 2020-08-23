namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IngredientsAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizzas", "Ingredients", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pizzas", "Ingredients");
        }
    }
}
