namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ingredientAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizzas", "Ingredient", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pizzas", "Ingredient");
        }
    }
}
