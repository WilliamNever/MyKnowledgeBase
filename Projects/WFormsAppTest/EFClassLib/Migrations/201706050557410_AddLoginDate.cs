namespace EFClassLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoginDate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfors",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 20),
                        id = c.Int(nullable: false, identity: true),
                        Password = c.String(nullable: false, maxLength: 32),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        LoginDate = c.DateTime(nullable: false, defaultValueSql:"getdate()"),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInfors");
        }
    }
}
