using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HtmlToPdf
{
    public class PDFHelper
    {
        public byte[] ConvertHtmlTextToPDF(string htmlText)
        {
            if (string.IsNullOrEmpty(htmlText))
            {
                return null;
            }
            //避免当htmlText无任何html tag标签的纯文字时，转PDF时会挂掉，所以一律加上<p>标签  
            htmlText = "<p>" + htmlText + "</p>";
            MemoryStream outputStream = new MemoryStream();//要把PDF写到哪个串流  
            byte[] data = Encoding.UTF8.GetBytes(htmlText);//字串转成byte[]  
            MemoryStream msInput = new MemoryStream(data);
            Document doc = new Document();//要写PDF的文件，建构子没填的话预设直式A4  

            PdfWriter writer = PdfWriter.GetInstance(doc, outputStream);
            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 1f);
            //开启Document文件 
            doc.Open();
            //HeaderAndFooterEvent header = new HeaderAndFooterEvent();
            //header.tpl = writer.DirectContent.CreateTemplate(100, 100);
            //writer.PageEvent = header;

            //使用XMLWorkerHelper把Html parse到PDF档里  
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msInput, null, Encoding.UTF8, new UnicodeFontFactory());

            //将pdfDest设定的资料写到PDF档  
            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            writer.SetOpenAction(action);
            doc.Close();
            msInput.Close();
            outputStream.Close();
            //回传PDF档案   
            return outputStream.ToArray();

        }

        public byte[] ConvertHtmlTextToPDF(string htmlText, string styleCss)
        {
            if (string.IsNullOrEmpty(htmlText))
            {
                return null;
            }
            //避免当htmlText无任何html tag标签的纯文字时，转PDF时会挂掉，所以一律加上<p>标签  
            htmlText = "<p>" + htmlText + "</p>";
            MemoryStream outputStream = new MemoryStream();//要把PDF写到哪个串流  

            byte[] data = Encoding.UTF8.GetBytes(htmlText);//字串转成byte[]  
            MemoryStream msInput = new MemoryStream(data);

            byte[] dataCss = Encoding.UTF8.GetBytes(styleCss);//字串转成byte[]  
            MemoryStream cssStream = new MemoryStream(dataCss);

            Document doc = new Document();//要写PDF的文件，建构子没填的话预设直式A4  

            PdfWriter writer = PdfWriter.GetInstance(doc, outputStream);
            PdfDestination pdfDest = new PdfDestination(PdfDestination.XYZ, 0, doc.PageSize.Height, 1f);
            //开启Document文件 
            doc.Open();
            //HeaderAndFooterEvent header = new HeaderAndFooterEvent();
            //header.tpl = writer.DirectContent.CreateTemplate(100, 100);
            //writer.PageEvent = header;

            //使用XMLWorkerHelper把Html parse到PDF档里  
            XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msInput, cssStream, Encoding.UTF8, new UnicodeFontFactory());

            //将pdfDest设定的资料写到PDF档  
            PdfAction action = PdfAction.GotoLocalPage(1, pdfDest, writer);
            writer.SetOpenAction(action);
            doc.Close();
            msInput.Close();
            cssStream.Close();
            outputStream.Close();
            //回传PDF档案   
            return outputStream.ToArray();

        }
    }
    public class UnicodeFontFactory : FontFactoryImp
    {

        public override Font GetFont(string fontname, string encoding, bool embedded, float size, int style, BaseColor color, bool cached)
        {
            //string FontPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Font/");

            BaseFont bfYaHei =
            //BaseFont.CreateFont(FontPath + "msyh.ttc,1", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            return new Font(bfYaHei, size, style, color);
        }
    }

    public class HeaderAndFooterEvent : PdfPageEventHelper, IPdfPageEvent
    {
        public PdfTemplate tpl = null;
        public bool PAGE_NUMBER = true;
        private int PageCount = 1;
        //private static string FontPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Font/");
        private static BaseFont bfYaHei = BaseFont.CreateFont(@"C:\Windows\Fonts\msyh.ttc,1", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        private static iTextSharp.text.Font font = new Font(bfYaHei, 10, Font.NORMAL, BaseColor.BLACK);

        //重写 关闭一个页面时
        public override void OnEndPage(PdfWriter writer, Document document)
        {
            if (PAGE_NUMBER)
            {
                Phrase footer = new Phrase("https://procuretest.taylorcommunications.com/                                                                                第" + writer.PageNumber + "页/共   页", font);
                PdfContentByte cb = writer.DirectContent;

                //模版 显示总共页数
                cb.AddTemplate(tpl, document.Right - 54 + document.LeftMargin, document.Bottom - 15);//调节模版显示的位置


                //页脚显示的位置
                ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, footer, document.Right - 297 + document.LeftMargin, document.Bottom - 14, 0);
            }
        }
        //重写 打开一个新页面时
        public override void OnStartPage(PdfWriter writer, Document document)
        {
            if (PAGE_NUMBER)
            {
                PageCount += 1;
                writer.PageCount = PageCount;
            }
        }
        //关闭PDF文档时
        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            tpl.BeginText();
            tpl.SetFontAndSize(bfYaHei, 10);//生成的模版的字体、颜色
            tpl.ShowText(PageCount.ToString());//模版显示的内容
            tpl.EndText();
            tpl.ClosePath();
        }
        //定义输出文本
        public static Paragraph InsertTitleContent(string text)
        {

            Paragraph paragraph = new Paragraph(text, font);//新建一行

            paragraph.Alignment = Element.ALIGN_CENTER;//居中

            paragraph.SpacingBefore = 5;

            paragraph.SpacingAfter = 5;
            paragraph.SetLeading(1, 2);//每行间的间隔
            return paragraph;
        }
    }
}
