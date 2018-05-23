namespace Pos.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCommnit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Controller = c.String(),
                        Action = c.String(),
                        Message = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogModels");
        }
    }
}
