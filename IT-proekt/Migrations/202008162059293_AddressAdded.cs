﻿namespace IT_proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PizzaServices", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PizzaServices", "Address");
        }
    }
}
