namespace lmltfy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.lmltfy_SearchModel", "Brand", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.lmltfy_SearchModel", "Brand");
        }
    }
}
