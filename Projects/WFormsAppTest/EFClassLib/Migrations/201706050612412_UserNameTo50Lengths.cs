namespace EFClassLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameTo50Lengths : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserInfors");
            AlterColumn("dbo.UserInfors", "UserName", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.UserInfors", "UserName");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserInfors");
            AlterColumn("dbo.UserInfors", "UserName", c => c.String(nullable: false, maxLength: 20));
            AddPrimaryKey("dbo.UserInfors", "UserName");
        }
    }
}
