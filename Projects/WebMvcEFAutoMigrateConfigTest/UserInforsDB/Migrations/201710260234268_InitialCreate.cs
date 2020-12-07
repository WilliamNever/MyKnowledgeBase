namespace UserInforsDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 255, unicode: false),
                        Password = c.String(nullable: false, maxLength: 255, unicode: false),
                        Age = c.Int(),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserInfors", new[] { "UserName" });
            DropTable("dbo.UserInfors");
        }
    }
}
