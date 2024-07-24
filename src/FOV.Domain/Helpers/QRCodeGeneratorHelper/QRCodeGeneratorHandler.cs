using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Helpers.QRCodeGeneratorHelper;

public class QRCodeGeneratorHandler
{
    public Bitmap GenerateQRCode(string url, int size = 20)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        return qrCode.GetGraphic(size);
    }
}
