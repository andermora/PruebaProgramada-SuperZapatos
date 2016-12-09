namespace SuperZapatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Articles", "Description", c => c.String(maxLength: 254));
            AlterColumn("dbo.Stores", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Stores", "Address", c => c.String(maxLength: 254));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Address", c => c.String());
            AlterColumn("dbo.Stores", "Name", c => c.String());
            AlterColumn("dbo.Articles", "Description", c => c.String());
            AlterColumn("dbo.Articles", "Name", c => c.String());
        }
    }
}
