using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;


namespace ywcai.util.draw
{
    class CatchScreen
    {
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, System.Drawing.CopyPixelOperation dwRop);

        public Byte[] catDeskTop()
        {

            Bitmap screenBitmap;
            using (Graphics screenGraphic = Graphics.FromHwnd(IntPtr.Zero))
            {
                //根据屏幕大小建立位图，这就是最后截取到的*屏幕图像*
                screenBitmap = new Bitmap(GetScreenPixel()[0], GetScreenPixel()[1], screenGraphic);

                //screenBitmap = new Bitmap(300,200,screenGraphic);
                //建立位图相关Graphics
                Graphics bitmapGraphics = Graphics.FromImage(screenBitmap);
                //建立屏幕上下文
                IntPtr hdcScreen = screenGraphic.GetHdc();
                //建立位图上下文
                IntPtr hdcBitmap = bitmapGraphics.GetHdc();
                //将屏幕捕获保存在位图中
                BitBlt(hdcBitmap, 0, 0, GetScreenPixel()[0], GetScreenPixel()[1], hdcScreen, 0, 0, CopyPixelOperation.CaptureBlt | CopyPixelOperation.SourceCopy);
               // BitBlt(hdcBitmap, 0, 0, 300,200, hdcScreen, 0, 0, CopyPixelOperation.CaptureBlt | CopyPixelOperation.SourceCopy);
                //关闭位图句柄
                bitmapGraphics.ReleaseHdc(hdcBitmap);
                //关闭屏幕句柄
                screenGraphic.ReleaseHdc(hdcScreen);
                //释放位图对像
                bitmapGraphics.Dispose();
                //释放屏幕对像
                screenGraphic.Dispose();
                //screenBitmap.Save("e:\\test.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                MemoryStream mStream = new MemoryStream();
  
                screenBitmap.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] imgBuffer = new Byte[mStream.Length];
                mStream.Seek(0, SeekOrigin.Begin);
                mStream.Read(imgBuffer,0,(Int32)mStream.Length);
                return imgBuffer;
            }

        }
        public int[] GetScreenPixel()
        {
            System.Windows.Forms.Screen scr = System.Windows.Forms.Screen.PrimaryScreen;
            System.Drawing.Rectangle rc = scr.Bounds;
            int[] sp = new int[2] { rc.Width, rc.Height };
            return sp;
        }
    }
}
