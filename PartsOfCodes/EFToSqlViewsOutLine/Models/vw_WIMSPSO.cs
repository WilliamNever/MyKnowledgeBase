using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OrderTracking2.Model;

namespace OrderTracking2.Data.Models
{
    public class vw_WIMSPSO
    {
        public vw_WIMSPSO()
        {
            //    src = "";
            //    SONUM = "";
            //    LINENUM = null;
            //SOCREATED = DateTime.Now;
            //    REQDELDT = null;
            //    BAANINVOICE = "";
            //    BAANPO = "";
            //    BAANPOLINE = null;
            //    PODATE = null;
            //    VENDOR_ACCOUNT_NO = "";
            //    VENDOR_NM = "";
            //    ITEM = "";
            //    ITEMDESC = "";
            //    CUSTOMERORDERNO = "";
            //    REFA = "";
            //    REFB = "";
            //    BAANINVDATE = null;
            //    TRACKING126 = "";
            //    TRACKING152 = "";
            //    TRACKINGPC = "";
        }
        public string src { get; set; }
        public string SONUM { get; set; }
        public double? LINENUM { get; set; }
        public DateTime SOCREATED { get; set; }
        public DateTime REQDELDT { get; set; }
        public string BAANINVOICE { get; set; }
        public string BAANPO { get; set; }
        public double? BAANPOLINE { get; set; }
        public DateTime PODATE { get; set; }
        public string VENDOR_ACCOUNT_NO { get; set; }
        public string VENDOR_NM { get; set; }
        public string ITEM { get; set; }
        public string ITEMDESC { get; set; }
        public string LINESTATUS { get; set; }
        public string CUSTOMERORDERNO { get; set; }
        public string REFA { get; set; }
        public string REFB { get; set; }
        public DateTime BAANINVDATE { get; set; }
        public string TRACKING126 { get; set; }
        public string TRACKING152 { get; set; }
        public string TRACKINGPC { get; set; }
        [NotMapped]
        public List<TrackingInfo> TrackingInfo
        {
            get
            {
                var data = new List<TrackingInfo>();
                ParseTracking(data, TRACKING126 ?? "");
                ParseTracking(data, TRACKING152 ?? "");
                ParseTracking(data, TRACKINGPC ?? "");
                return data;
            }
        }

        protected static void ParseTracking(List<TrackingInfo> data, string trackingSourceString)
        {
            foreach (var t in trackingSourceString.Split(','))
            {
                try
                {
                    var tr = new TrackingInfo
                    {
                        Carrier = t.Substring(1, t.IndexOf(']') - 1),
                        TrackingNumber = t.Substring(t.IndexOf(']') + 2, t.IndexOf('(') > 0 ? (t.IndexOf('(') - t.Substring(1, t.IndexOf(']') - 1).Length - 4) : t.Length - t.Substring(1, t.IndexOf(']') - 1).Length - 3),
                        ShipDate = t.Contains("(") ? DateTime.Parse(t.Substring(t.IndexOf('(') + 1, 19)) : (DateTime?)null
                    };


                    if (tr.Carrier.ToUpper().Contains("UPS") &&
                        (tr.TrackingNumber.StartsWith("1z") || tr.TrackingNumber.StartsWith("1Z")))
                    {
                        tr.CarrierTrackingLink =
                            @"<a href=""http://wwwapps.ups.com/WebTracking/processInputRequest?tracknum=" +
                            tr.TrackingNumber + @""" target=""_blank"">" + tr.TrackingNumber + @"</a><br/>";
                    }
                    else if (tr.Carrier.ToUpper().Contains("FEDEX") && !tr.Carrier.ToUpper().Contains("FREIGHT") &&
                             (tr.TrackingNumber.Length == 12) || (tr.TrackingNumber.Length == 15))
                    {
                        tr.CarrierTrackingLink =
                            @"<a href=""http://www.fedex.com/Tracking?language=english&cntry_code=us&tracknumbers=" +
                            tr.TrackingNumber + @""" target=""_blank"">" + tr.TrackingNumber + @"</a><br/>";
                    }
                    else
                    {
                        tr.CarrierTrackingLink = tr.TrackingNumber + "<br/>";
                    }
                    data.Add(tr);
                }
                catch (Exception ex)
                {

                    //eat the exception for now
                }
            }
        }
    }
}
