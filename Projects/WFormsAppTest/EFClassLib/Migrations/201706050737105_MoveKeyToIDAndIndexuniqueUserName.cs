namespace EFClassLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveKeyToIDAndIndexuniqueUserName : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserInfors");
            AddPrimaryKey("dbo.UserInfors", "id");
            CreateIndex("UserInfors", "UserName", unique: true, name: "UserNameUniqueIndex", clustered: false);
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserInfors");
            AddPrimaryKey("dbo.UserInfors", "UserName");
            DropIndex("UserInfors", "UserNameUniqueIndex");
        }
    }
}
