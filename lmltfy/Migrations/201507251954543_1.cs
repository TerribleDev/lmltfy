namespace lmltfy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.lmltfy_SearchModel",
                c => new
                    {
                        Url = c.String(nullable: false, maxLength: 128),
                        Search = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Url);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.lmltfy_SearchModel");
        }
    }
}
