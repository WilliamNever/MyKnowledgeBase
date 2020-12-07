using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleForDNetFrameWork.DBModels
{
    public partial class DBCTXTContext : DbContext
    {
        protected string ConnectionString;

        public DBCTXTContext()
        {
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnString"].ConnectionString;
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
        public virtual DbSet<UserInfors> UserInfors { get; set; }
        public virtual DbSet<RInfor> RentInfors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
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
