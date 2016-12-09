namespace SuperZapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreIdRelationShip : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Articles", "StoreId");
            AddForeignKey("dbo.Articles", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "StoreId", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "StoreId" });
        }
    }
}
