namespace tinyCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskItems", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TaskItems", new[] { "User_Id" });
            AddColumn("dbo.TaskItems", "UserId", c => c.String());
            DropColumn("dbo.TaskItems", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskItems", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.TaskItems", "UserId");
            CreateIndex("dbo.TaskItems", "User_Id");
            AddForeignKey("dbo.TaskItems", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
