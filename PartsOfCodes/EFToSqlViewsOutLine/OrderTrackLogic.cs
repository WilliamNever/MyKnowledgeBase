using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTracking2.Data.Models;

namespace OrderTracking2.Data
{
    public class OrderTrackLogic
    {
        private string BP;
        public OrderTrackLogic(string bp)
        {
            BP = bp;
        }
        public IEnumerable<vw_WIMSPSO> GetLines(string Origin, string Reference, bool UseWildcard)
        {
            var dc = new OrderDataContext(ConfigurationManager.AppSettings[BP]);
            dc.Database.CommandTimeout = 1200;

            IQueryable<vw_WIMSPSO> data = null;
            switch (BP)
            {
                case "HRB":
                    var mybase = dc.vw_WIMSPSO_HRBs.AsQueryable();
                    data = from x in mybase
                           select new vw_WIMSPSO
                           {
                               src = x.src,
                               SONUM = x.SONUM,
                               LINENUM = x.LINENUM,
                               SOCREATED = x.SOCREATED,
                               REQDELDT = x.REQDELDT,
                               BAANINVOICE = x.BAANINVOICE,
                               BAANPO = x.BAANPO,
                               BAANPOLINE = x.BAANPOLINE,
                               PODATE = x.PODATE,
                               VENDOR_ACCOUNT_NO = x.VENDOR_ACCOUNT_NO,
                               VENDOR_NM = x.VENDOR_NM,
                               ITEM = x.ITEM,
                               ITEMDESC = x.ITEMDESC,
                               LINESTATUS = x.LINESTATUS,
                               CUSTOMERORDERNO = x.CUSTOMERORDERNO,
                               REFA = x.REFA,
                               REFB = x.REFB,
                               BAANINVDATE = x.BAANINVDATE,
                               TRACKING126 = x.TRACKING126,
                               TRACKING152 = x.TRACKING152,
                               TRACKINGPC = x.TRACKINGPC
                           };
                    break;
                case "STAPLES":
                    var mybase_Staples = dc.vw_WIMSPSO_Stapleses.AsQueryable();
                    data = from x in mybase_Staples
                           select new vw_WIMSPSO
                           {
                               src = x.src,
                               SONUM = x.SONUM,
                               LINENUM = x.LINENUM,
                               SOCREATED = x.SOCREATED,
                               REQDELDT = x.REQDELDT,
                               BAANINVOICE = x.BAANINVOICE,
                               BAANPO = x.BAANPO,
                               BAANPOLINE = x.BAANPOLINE,
                               PODATE = x.PODATE,
                               VENDOR_ACCOUNT_NO = x.VENDOR_ACCOUNT_NO,
                               VENDOR_NM = x.VENDOR_NM,
                               ITEM = x.ITEM,
                               ITEMDESC = x.ITEMDESC,
                               LINESTATUS = x.LINESTATUS,
                               CUSTOMERORDERNO = x.CUSTOMERORDERNO,
                               REFA = x.REFA,
                               REFB = x.REFB,
                               BAANINVDATE = x.BAANINVDATE,
                               TRACKING126 = x.TRACKING126,
                               TRACKING152 = x.TRACKING152,
                               TRACKINGPC = x.TRACKINGPC
                           };
                    break;
                case "TAYLOR":
                default:
                    var mybase_Taylor = dc.vw_WIMSPSO_TAYLORs.AsQueryable();
                    data = from x in mybase_Taylor
                           select new vw_WIMSPSO
                           {
                               src = x.src,
                               SONUM = x.SONUM,
                               LINENUM = x.LINENUM,
                               SOCREATED = x.SOCREATED,
                               REQDELDT = x.REQDELDT,
                               BAANINVOICE = x.BAANINVOICE,
                               BAANPO = x.BAANPO,
                               BAANPOLINE = x.BAANPOLINE,
                               PODATE = x.PODATE,
                               VENDOR_ACCOUNT_NO = x.VENDOR_ACCOUNT_NO,
                               VENDOR_NM = x.VENDOR_NM,
                               ITEM = x.ITEM,
                               ITEMDESC = x.ITEMDESC,
                               LINESTATUS = x.LINESTATUS,
                               CUSTOMERORDERNO = x.CUSTOMERORDERNO,
                               REFA = x.REFA,
                               REFB = x.REFB,
                               BAANINVDATE = x.BAANINVDATE,
                               TRACKING126 = x.TRACKING126,
                               TRACKING152 = x.TRACKING152,
                               TRACKINGPC = x.TRACKINGPC
                           };
                    break;
            }


            switch (Origin)
            {
                case "Source Express":
                    if (!UseWildcard)
                        data = data.Where(s => s.CUSTOMERORDERNO.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.CUSTOMERORDERNO.ToLower().Contains(Reference.ToLower()));
                    break;
                case "Customer Order Number":
                    if (!UseWildcard)
                        data = data.Where(s => s.CUSTOMERORDERNO.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.CUSTOMERORDERNO.ToLower().Contains(Reference.ToLower()));
                    break;
                case "BAAN PO":
                    if (!UseWildcard)
                        data = data.Where(s => s.BAANPO == Reference.ToUpper());
                    else
                        data = data.Where(s => s.BAANPO.Contains(Reference.ToUpper()));
                    break;
                case "BAAN SO":
                    if (!UseWildcard)
                        data = data.Where(s => s.SONUM.Equals(Reference.ToUpper()));
                    else
                        data = data.Where(s => s.SONUM.Contains(Reference.ToUpper()));
                    break;
                case "ISIS PO":
                    if (!UseWildcard)
                        data = data.Where(s => s.REFA.Substring(4, 10).Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.REFA.Substring(4, 10).ToLower().Contains(Reference.ToLower()));
                    break;
                case "ISIS SO":
                    if (!UseWildcard)
                        data = data.Where(s => s.REFA.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.REFA.ToLower().Contains(Reference.ToLower()));
                    break;
                case "BAAN REF A":
                    if (!UseWildcard)
                        data = data.Where(s => s.REFA.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.REFA.ToLower().Contains(Reference.ToLower()));
                    break;
                case "Sunrise PO":
                    if (!UseWildcard)
                        data = data.Where(s => s.CUSTOMERORDERNO.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.CUSTOMERORDERNO.ToLower().Contains(Reference.ToLower()));
                    break;
                case "BAAN REF B":
                    if (!UseWildcard)
                        data = data.Where(s => s.REFB.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.REFB.ToLower().Contains(Reference.ToLower()));
                    break;
                case "Staples Link":
                    if (!UseWildcard)
                        data = data.Where(s => s.CUSTOMERORDERNO.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.CUSTOMERORDERNO.ToLower().Contains(Reference.ToLower()));
                    break;
                case "Eway Reference":
                    if (!UseWildcard)
                        data = data.Where(s => s.CUSTOMERORDERNO.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.CUSTOMERORDERNO.ToLower().Contains(Reference.ToLower()));
                    break;
                default://If they didn't pick anything, default it to CORN.
                    if (!UseWildcard)
                        data = data.Where(s => s.CUSTOMERORDERNO.Equals(Reference, StringComparison.CurrentCultureIgnoreCase));
                    else
                        data = data.Where(s => s.CUSTOMERORDERNO.ToLower().Contains(Reference.ToLower()));
                    break;
            }
            var result = data;
            return data.Take(int.Parse(ConfigurationManager.AppSettings["ResultLimit"])).OrderBy(s => s.SONUM).ThenBy(s => s.LINENUM).ThenBy(p => p.BAANPO).ThenBy(p => p.BAANPOLINE).ToList();
        }

        public DateTime GetNewestSODateTime()
        {
            var dc = new OrderDataContext(ConfigurationManager.AppSettings[BP]);
            dc.Database.CommandTimeout = 120;
            // (from ord in dc.TTDSLS921100s select ord).OrderByDescending(l => l.T_LINEDATE).FirstOrDefault().T_LINEDATE.Subtract(new TimeSpan(6, 0, 0)).ToString();
            //var datetime =  dc.Database.SqlQuery<DateTime>("SELECT top 1 T$LINEDATE FROM TTDSLS921100 order by T$LINEDATE desc");
            var datetime = dc.Database.SqlQuery<DateTime>("Select EffectiveDate FROM[COGNOS_STATUS].[dbo].[ETL_MASTER_LIST] Where ETL_Build = 'SPSC_WIMSPSO_DoTodayMerge'");
            //var datetime = dc.Database.SqlQuery<DateTime>("Select max(EffectiveDate) FROM[COGNOS_STATUS].[dbo].[ETL_MASTER_LIST]");
            return datetime.First();
        }
    }
}