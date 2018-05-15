namespace tinyCRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskItems", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TaskItems", "User_Id");
            AddForeignKey("dbo.TaskItems", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.TaskItems", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskItems", "UserId", c => c.String());
            DropForeignKey("dbo.TaskItems", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TaskItems", new[] { "User_Id" });
            DropColumn("dbo.TaskItems", "User_Id");
        }
    }
}
