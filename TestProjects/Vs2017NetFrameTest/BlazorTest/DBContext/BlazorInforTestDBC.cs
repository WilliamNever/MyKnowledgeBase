using BlazorTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.DBContext
{
    public class BlazorInforTestDBC : DbContext
    {
        protected string ConnectionString;
        public Guid ID = Guid.NewGuid();

        public BlazorInforTestDBC()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.Development.json", optional: true)
                ;
            ConnectionString = builder.Build().GetValue<string>("AppSettings:ConnectionString");
        }
        public BlazorInforTestDBC(string ConnString)
        {
            ConnectionString = ConnString;
        }

        public BlazorInforTestDBC(DbContextOptions<BlazorInforTestDBC> options)
            : base(options)
        {
        }

        public virtual DbSet<InforModel> InforModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
