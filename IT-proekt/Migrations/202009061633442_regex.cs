namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class regex : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardNumber = c.String(nullable: false),
                        Expiration = c.String(nullable: false),
                        Cvc = c.String(nullable: false),
                        CardOwner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.OrderForms");
        }
    }
}
