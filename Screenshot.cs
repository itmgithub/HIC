using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace HIC
{
    class Screenshot
    {

        // Maak een PNG van het huidige scherm. Geef de filename terug als return value.
        public List<string> takeScreenshot(Form parent)
        {
            string tmpFName;
            List<string> fName = new List<string>();

            try
            {
                parent.WindowState = FormWindowState.Minimized;
                System.Threading.Thread.Sleep(500); // So that HOH kan minimize.
                foreach (Screen screen in Screen.AllScreens)
                {
                    tmpFName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".png";
                    var bmpImage = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, PixelFormat.Format32bppArgb);
                    var gfxImage = Graphics.FromImage(bmpImage);
                    gfxImage.CopyFromScreen(screen.Bounds.X,
                                        screen.Bounds.Y,
                                        0,
                                        0,
                                        new Size(screen.Bounds.Width, screen.Bounds.Height),
                                        //screen.Bounds.Size, 
                                        CopyPixelOperation.SourceCopy);
                    bmpImage.Save(tmpFName);
                    fName.Add(tmpFName);
                    gfxImage.Dispose();
                    bmpImage.Dispose();
                }
                return fName;
            }
            catch
            {
                return null;
            }
        }
    }
}
