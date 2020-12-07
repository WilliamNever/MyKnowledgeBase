namespace ExtendInforsDB
{
    using System;
    using System.Data.Entity;

    public class ExtendInforsDBContext : DbContext
    {
        // Your context has been configured to use a 'ExtendInforsDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ExtendInforsDB.ExtendInforsDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ExtendInforsDB' 
        // connection string in the application configuration file.
        public ExtendInforsDBContext()
            : base("name=ExtendInforsDB")
        {
        }
        public ExtendInforsDBContext(string ConnectionStringName)
            : base("name=" + ConnectionStringName)
        { }

        public virtual DbSet<OrdersInfors> OrdersInfors { get; set; }
    }
}