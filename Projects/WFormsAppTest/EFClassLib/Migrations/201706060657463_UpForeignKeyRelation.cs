namespace EFClassLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpForeignKeyRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Email = c.String(),
                        addr = c.String(),
                        phone = c.String(),
                        AddIdentity = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.UserInfors", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserID", "dbo.UserInfors");
            DropIndex("dbo.Addresses", new[] { "UserID" });
            DropTable("dbo.Addresses");
        }
    }
}
