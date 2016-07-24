using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ywcai.global.config;

namespace ywcai.util.draw
{
    class CatchScreen
    {
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, System.Drawing.CopyPixelOperation dwRop);
        public List<ImgEntity> getImgs()
        {
            List<ImgEntity> imgs = new List<ImgEntity>();
            Int32[] screenXY = GetScreenPixel();
            for (int indexX = 1; indexX <= MyConfig.INT_BLOCK_X_COUNT; indexX++)
            {
                for(int indexY=1; indexY<=MyConfig.INT_BLOCK_Y_COUNT;indexY++ )
                {
                    ImgEntity imgEntity = new ImgEntity();
                    imgEntity.width = screenXY[0] / MyConfig.INT_BLOCK_X_COUNT;
                    imgEntity.height = screenXY[1] / MyConfig.INT_BLOCK_Y_COUNT;
                    imgEntity.posX = (indexX - 1) * imgEntity.width;
                    imgEntity.posY = (indexY - 1) * imgEntity.height;
                    if (indexX == MyConfig.INT_BLOCK_X_COUNT)
                    {
                        imgEntity.width = imgEntity.width + (screenXY[0] % MyConfig.INT_BLOCK_X_COUNT);
                    }
                    if (indexY==MyConfig.INT_BLOCK_Y_COUNT)
                    {
                        imgEntity.height = imgEntity.height + (screenXY[1] % MyConfig.INT_BLOCK_Y_COUNT);
                    }
                    Graphics screenGraphic = Graphics.FromHwnd(IntPtr.Zero);
                    Bitmap screenBitmap = new Bitmap(imgEntity.width, imgEntity.height, screenGraphic);
                    Graphics bitmapGraphics = Graphics.FromImage(screenBitmap);
                    IntPtr hdcScreen = screenGraphic.GetHdc();
                    IntPtr hdcBitmap = bitmapGraphics.GetHdc();
                    BitBlt(hdcBitmap, 0, 0, imgEntity.width, imgEntity.height, hdcScreen, imgEntity.posX, imgEntity.posY, CopyPixelOperation.CaptureBlt | CopyPixelOperation.SourceCopy);
                    screenGraphic.ReleaseHdc(hdcScreen);
                    bitmapGraphics.ReleaseHdc(hdcBitmap);
                    bitmapGraphics.Dispose();
                    screenGraphic.Dispose();
                    MemoryStream mStream = new MemoryStream();
                    ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo imgInfo = null;
                    foreach (ImageCodecInfo ici in CodecInfo)
                    {
                        if (ici.MimeType == "image/jpeg")
                        {
                            imgInfo = ici;
                        }
                    }
                    EncoderParameter p = new EncoderParameter(Encoder.Quality,MyConfig.INT_DESKTOP_QA);
                    EncoderParameters ps = new EncoderParameters(1);
                    ps.Param[0] = p;
                    screenBitmap.Save(mStream, imgInfo, ps);
                    Byte[] imgBuffer = new Byte[mStream.Length];
                    mStream.Seek(0, SeekOrigin.Begin);
                    mStream.Read(imgBuffer, 0, (Int32)mStream.Length);
                    imgEntity.body = imgBuffer;
                    imgs.Add(imgEntity);
                }
            }
            return imgs;
        }
        public int[] GetScreenPixel()
        {
            Screen scr = Screen.PrimaryScreen;
            Rectangle rc = scr.Bounds;
            int[] sp = new int[2] { rc.Width, rc.Height };
            return sp;
        }
    }
}
