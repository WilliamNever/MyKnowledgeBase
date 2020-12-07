using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using OrderTracking2.Data.Models;
using OrderTracking2.Data.Models.Mapping;

namespace OrderTracking2.Data
{
    internal class OrderDataContext : DbContext
    {
        private string tableMap;
        public OrderDataContext()
        {
            //Database.SetInitializer<OrderDataContext>(null);

            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public OrderDataContext(string tableMapName)
        {
            //Database.SetInitializer<OrderDataContext>(null);
            tableMap = tableMapName;
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<vw_WIMSPSO_Staples> vw_WIMSPSO_Stapleses { get; set; }
        public DbSet<vw_WIMSPSO_HRB> vw_WIMSPSO_HRBs { get; set; }
        public DbSet<vw_WIMSPSO_TAYLOR> vw_WIMSPSO_TAYLORs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new vw_WIMSPSO_STAPLES_Query_Map());
            modelBuilder.Configurations.Add(new vw_WIMSPSO_HRB_Query_Map());
            modelBuilder.Configurations.Add(new vw_WIMSPSO_Query_Map());
        }
    }

    #region Maps
    public class vw_WIMSPSO_STAPLES_Query_Map : vw_WIMSPSOMap<vw_WIMSPSO_Staples>
    {
        public vw_WIMSPSO_STAPLES_Query_Map() : base("vw_WIMSPSO_STAPLES_Query")
        {

        }
    }
    public class vw_WIMSPSO_HRB_Query_Map : vw_WIMSPSOMap<vw_WIMSPSO_HRB>
    {
        public vw_WIMSPSO_HRB_Query_Map() : base("vw_WIMSPSO_HRB_Query")
        {

        }
    }
    public class vw_WIMSPSO_Query_Map : vw_WIMSPSOMap<vw_WIMSPSO_TAYLOR>
    {
        public vw_WIMSPSO_Query_Map() : base("vw_WIMSPSO_Query")
        {

        }
    }
    #endregion

    #region Model Values
    public class vw_WIMSPSO_Staples : vw_WIMSPSO { }
    public class vw_WIMSPSO_HRB : vw_WIMSPSO { }
    public class vw_WIMSPSO_TAYLOR : vw_WIMSPSO { }
    #endregion
}
