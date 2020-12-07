using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ConsoleCoreTest.DBModels
{
    public partial class DBCTXTContext : DbContext
    {
        protected string ConnectionString;
        public Guid ID = Guid.NewGuid();

        public DBCTXTContext()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("APP.json");
            ConnectionString = builder.Build()["ConnetionString:value"];
        }
        public DBCTXTContext(string ConnString)
        {
            ConnectionString = ConnString;
        }

        public DBCTXTContext(DbContextOptions<DBCTXTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        //public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<UserInfors> UserInfors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DBCTXT;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;user id=sa;password=sa");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserID");

                entity.Property(e => e.AddIdentity).HasDefaultValueSql("(newsequentialid())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Addresses_dbo.UserInfors_UserID");
            });

            modelBuilder.Entity<UserInfors>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameUniqueIndex")
                    .IsUnique();

                entity.Property(e => e.LoginDate).HasDefaultValueSql("(getdate())");
            });
        }

    }
}
