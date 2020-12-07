namespace ExtendInforsDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrdersInfors",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    UserName = c.String(nullable: false, maxLength: 255, unicode: false),
                    OrderNumber = c.String(nullable: false, maxLength: 255, unicode: false),
                    CreateDate = c.DateTime(nullable: false, defaultValueSql: "getdate()"),
                    Status = c.Int(nullable: false),
                    StatusChangedDate = c.DateTime(nullable: false),
                    CheckedUserName = c.String(nullable: false, maxLength: 255, unicode: false),
                })
                .PrimaryKey(t => t.ID)
                .Index(t => t.UserName)
                .Index(t => t.OrderNumber, unique: true);

        }
        
        public override void Down()
        {
            DropIndex("dbo.OrdersInfors", new[] { "OrderNumber" });
            DropIndex("dbo.OrdersInfors", new[] { "UserName" });
            DropTable("dbo.OrdersInfors");
        }
    }
}
