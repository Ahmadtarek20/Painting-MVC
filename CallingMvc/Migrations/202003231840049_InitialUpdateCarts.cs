namespace CallingMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpdateCarts : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "UserId");
            DropColumn("dbo.Carts", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "UserId", c => c.Int(nullable: false));
        }
    }
}
