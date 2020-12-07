using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HtmlToPdf
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnHtmlToPDF_Click(object sender, EventArgs e)
        {
            
            string htm =
            #region htm contents
                @"
                    <html>
<head>
<style type=""text/css"">
  .style1 {
            border-collapse: collapse;
            border-style: solid;
            border-width: 1px;
            border-color: black;} 
.boderWidth{border: 1px solid black;border-collapse: collapse;}
.f15{font-size:15px;}
</style>
</head>


<body>

	<table style=""width: 100%"">
			<tr>
				<td style=""width: 60%;font-weight:bold"" valign=""middle"" rowspan=""2""><h2><b style=""font-family:timesbd"">TAYLOR SPOC<br /> <BR/>Pro.Cure Invoice</b></h2></td>
				<td style=""width: 20%"">Invoice No.</td>
				<td style=""width: 20%"">123456</td>
			</tr>
			<tr>
				
				<td style=""width: 10%"">Invoice Date:</td>
				<td style=""width: 20%"">5/2/2018</td>
			</tr>
	</table>
	<BR/>
	<table style=""width: 100%"">
		<tr>
			<td style=""width: 5%"">Bill To:</td>
			<td style=""width: 50%"" class=""f15"">Taylor Communications, Inc. (d/b/a Staples Print Solutions)<br/>
4205 SOUTH 96TH STREET<br/>
OMAHA, NE 68127</td>
			<td style=""width: 5%"">Ship To:</td>
			<td style=""width: 40%;"" class=""f15"">Attn : EARLY MOUNTAIN VINEYARD<br />6109 WOLFTOWN HOOD RD<br />MADISON HEIGHTS, VA 22727</td>
		</tr>
	</table>
	<BR/>
	<table style=""width: 100%; height: 15px;"">
		<tr>
			<td style=""width: 10%; height: 10px;""><B>Purchase Order:</B></td>
			<td style=""width: 10%; height: 10px;""><B>Ship Date:</B></td>
			<td style=""width: 25%; height: 10px;""><B>Buyer:</B></td>
			<td style=""width: 20%; height: 10px;""><B>Terms:</B></td>
			<td style=""width: 15%; height: 10px;""><B>Ship Via:</B></td>
			<td style=""width: 20%; height: 10px;""><B>Tracking Numbers:</B></td>
		</tr>
		<tr height=""40px"">
			<td style=""width: 10%"" valign=""top"">RT-093364</td>
			<td style=""width: 10%"" valign=""top"">5/2/2018</td>
			<td style=""width: 25%"" valign=""top"">RETAIL<br />1212-462-7457</td>
			<td style=""width: 20%"" valign=""top"">2% 20 Days Net 45 5.5% Rebate</td>
			<td style=""width: 15%"" valign=""top"">COURIER</td>
			<td style=""width: 20%"" valign=""top"">12345678-99</td>
		</tr>
	</table>
<BR/>
	<table border=""1"" class=""boderWidth"" width=""100%"">
		<tr>
			<td style=""width: 5%"" align=""left"">Line</td>
			<td style=""width: 20%"" align=""left"">Item</td>
			<td style=""width: 30%"" align=""left"">Description</td>
			<td style=""width: 5%"" align=""left"">Ordered Qty</td>
			<td style=""width: 5%"" align=""left"">Shipped Qty</td>
			<td style=""width: 15%"" align=""left"">Unit Price</td>
			<td style=""width: 10%"" align=""left"">UOM</td>
			<td style=""width: 10%"" align=""left"">Line Total</td>
		</tr>
		<tr>
		<td style="""" align=""left"">10</td>
		<td style="""" align=""left"">STPLR742086FLYER</td>
		<td style="""" align=""left"">OUTSOURCE-FLYER</td>
		<td style="""" align=""left"">2500</td>
		<td style="""" align=""left"">2500</td>
		<td style="""" align=""left"">0.1434</td>
		<td style="""" align=""left"">EA</td>
		<td style="""" align=""left"">$358.50</td>
</tr>
	</table>
	<br/>
	<table width=""100%"" >
		<tr>
			<td style=""width: 40%""></td>
			<td style=""border-width: 1px;width: 15%;padding:3px;""><b>Merchandise</b></td>
			<td style=""border-width: 1px;width: 15%;padding:3px;""><b>Addt'l Charges</b></td>
			<td style=""border-width: 1px;width: 15%;padding:3px;""><b>Freight</b></td>
			<td style=""border-width: 1px;width: 15%;padding:3px;""><b>Total Due</b></td>
		</tr>

		<tr>
			<td style=""width: 40%""></td>
			<td style=""border-width: 1px;padding:3px;"">$358.50</td>
			<td style=""border-width: 1px;padding:3px;"">$0.00</td>
			<td style=""border-width: 1px;padding:3px;"">$0.00</td>
			<td style=""border-width: 1px;padding:3px;"">$358.50</td>
		</tr>
	</table>
</body>

</html>
                            "
            #endregion
            ;

            PDFHelper helper = new HtmlToPdf.PDFHelper();
            var bytes =
                helper.ConvertHtmlTextToPDF(htm);
            //    helper.ConvertHtmlTextToPDF(htm, @".style1 {
            //border-collapse: collapse;
            //border-style: solid;
            //border-width: 1px;
            //border-color: black;} .boderWidth{border: 1px solid;} ")
            ;
            FileStream fs = new FileStream("aa.pdf", FileMode.Create);
            fs.Write(bytes, 0, bytes.Length);
            fs.Flush();
            fs.Close();

            MessageBox.Show("Over!");
        }
    }

    /// <summary>
    /// 重写iTextSharp字体(仅仅使用宋体)
    /// </summary>
    public class SongFontFactory : IFontProvider
    {
        public iTextSharp.text.Font GetFont(String fontname, String encoding, Boolean embedded, float size, int style, BaseColor color)
        {

            BaseFont bf3 = BaseFont.CreateFont(@"c:\windows\fonts\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontContent = new iTextSharp.text.Font(bf3, size, style, color);
            return fontContent;

        }
        public Boolean IsRegistered(String fontname)
        {
            return false;
        }
    }

}
