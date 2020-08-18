namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PizzaServicePizzas", "PizzaService_Id", "dbo.PizzaServices");
            DropForeignKey("dbo.PizzaServicePizzas", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.PizzaServicePizzas", new[] { "PizzaService_Id" });
            DropIndex("dbo.PizzaServicePizzas", new[] { "Pizza_Id" });
            DropTable("dbo.PizzaServices");
            DropTable("dbo.PizzaServicePizzas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PizzaServicePizzas",
                c => new
                    {
                        PizzaService_Id = c.Int(nullable: false),
                        Pizza_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PizzaService_Id, t.Pizza_Id });
            
            CreateTable(
                "dbo.PizzaServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.PizzaServicePizzas", "Pizza_Id");
            CreateIndex("dbo.PizzaServicePizzas", "PizzaService_Id");
            AddForeignKey("dbo.PizzaServicePizzas", "Pizza_Id", "dbo.Pizzas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PizzaServicePizzas", "PizzaService_Id", "dbo.PizzaServices", "Id", cascadeDelete: true);
        }
    }
}
