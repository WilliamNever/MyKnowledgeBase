namespace UserInforsDB
{
    using System;
    using System.Data.Entity;

    public class UserInforsDBContext : DbContext
    {
        // Your context has been configured to use a 'UserInforsDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'UserInforsDB.UserInforsDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UserInforsDB' 
        // connection string in the application configuration file.
        public UserInforsDBContext()
            : base("name=UserInforsDB")
        {
        }
        public UserInforsDBContext(string ConnectionStringName)
            : base("name=" + ConnectionStringName)
        { }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<UserInfors> UserInfors { get; set; }
    }
}