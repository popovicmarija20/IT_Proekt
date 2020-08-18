namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PizzaServicePizzas",
                c => new
                    {
                        PizzaService_Id = c.Int(nullable: false),
                        Pizza_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PizzaService_Id, t.Pizza_Id })
                .ForeignKey("dbo.PizzaServices", t => t.PizzaService_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id, cascadeDelete: true)
                .Index(t => t.PizzaService_Id)
                .Index(t => t.Pizza_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PizzaServicePizzas", "Pizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.PizzaServicePizzas", "PizzaService_Id", "dbo.PizzaServices");
            DropIndex("dbo.PizzaServicePizzas", new[] { "Pizza_Id" });
            DropIndex("dbo.PizzaServicePizzas", new[] { "PizzaService_Id" });
            DropTable("dbo.PizzaServicePizzas");
            DropTable("dbo.PizzaServices");
            DropTable("dbo.Pizzas");
        }
    }
}
