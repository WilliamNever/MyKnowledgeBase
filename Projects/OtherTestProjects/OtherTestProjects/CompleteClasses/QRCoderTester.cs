using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTestProjects.CompleteClasses
{
    public class QRCoderTester
    {
        private QRCodeGenerator qrGenerator;

        public QRCoderTester()
        {
            qrGenerator = new QRCoder.QRCodeGenerator();
        }

        public Bitmap GetQRBitmap(string str)
        {
            Bitmap rValue = null;
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.Q, true);
            QRCode qrcode = new QRCode(qrCodeData);
            //var icon = qrcode.GetGraphic(10, Color.Brown, Color.Silver, null, 15, 2, false);
            rValue = qrcode.GetGraphic(2, Color.DarkGreen, Color.White, true);
            return rValue;
        }
    }
}
