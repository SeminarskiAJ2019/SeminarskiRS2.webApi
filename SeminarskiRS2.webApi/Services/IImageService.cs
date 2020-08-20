using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;


namespace SeminarskiRS2.webApi.Services
{
    public interface IImageService
    {
        byte[] ImageToBytes(Image img);
        Image BytesToImage(byte[] arr);
        Image GetNoImage();
        Image ImageToThumbnail(Image image);
        bool ThumbnailCallback();
    }
}
