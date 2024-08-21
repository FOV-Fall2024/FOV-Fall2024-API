﻿using System.Drawing;
using QRCoder;

namespace FOV.Domain.Helpers.QRCodeGeneratorHelper;

public   class QRCodeGeneratorHandler
{
    public  Bitmap GenerateQRCode(string url, int size = 20)
    {
        QRCodeGenerator qrGenerator = new();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new(qrCodeData);
        return qrCode.GetGraphic(size);
    }
}
