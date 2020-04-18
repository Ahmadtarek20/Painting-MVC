namespace CallingMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 40),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Category_CareguryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CareguryId)
                .Index(t => t.Category_CareguryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CareguryId = c.Int(nullable: false, identity: true),
                        Categury_Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.CareguryId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_CareguryId", "dbo.Categories");
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropIndex("dbo.Photos", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "Category_CareguryId" });
            DropIndex("dbo.Carts", new[] { "ProductId" });
            DropTable("dbo.Photos");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Carts");
        }
    }
}
