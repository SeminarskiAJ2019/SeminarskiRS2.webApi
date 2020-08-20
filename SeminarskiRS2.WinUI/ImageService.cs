using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskiRS2.WinUI
{
    public class ImageService
    {
        public Image BytesToImage(byte[] arr)
        {
            MemoryStream ms = new MemoryStream(arr);
            return Image.FromStream(ms);
        }
        public Image GetNoImage()
        {
            string path = Path.GetDirectoryName(Environment.CurrentDirectory);
            string[] path2 = path.Split(new[] { "\\" }, StringSplitOptions.None);
            string p = path2[0] + "\\" + path2[1] + "\\" + path2[2] + "\\slike\\noimage.jpg";
            return Image.FromFile(p);
        }

        public byte[] ImageToBytes(Image img)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            Image mythumb = img.GetThumbnailImage(100, 100, myCallback, IntPtr.Zero);
            var ms = new MemoryStream();
            mythumb.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public Image ImageToThumbnail(Image image)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image mythumb = image.GetThumbnailImage(100, 100, myCallback, IntPtr.Zero);
            return mythumb;
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
    }
}
