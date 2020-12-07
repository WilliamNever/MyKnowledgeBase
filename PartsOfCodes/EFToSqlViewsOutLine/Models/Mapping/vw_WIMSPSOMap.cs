using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace OrderTracking2.Data.Models.Mapping
{
    public class vw_WIMSPSOMap<T>: EntityTypeConfiguration<T>
        where T: vw_WIMSPSO
    {
        public vw_WIMSPSOMap(string tableMapName)
        {
            // Primary Key
            this.HasKey(t => new { t.src, t.SONUM, t.LINENUM, t.BAANPO, t.BAANPOLINE, t.BAANINVOICE });

            // Table & Column Mappings
            this.ToTable(tableMapName);
        }
    }
}
