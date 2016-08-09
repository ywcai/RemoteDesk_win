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
                for (int indexY = 1; indexY <= MyConfig.INT_BLOCK_Y_COUNT; indexY++)
                {
                    ImgEntity imgEntity = new ImgEntity();
                    imgEntity.width = (short)(screenXY[0] / MyConfig.INT_BLOCK_X_COUNT);
                    imgEntity.height = (short)(screenXY[1] / MyConfig.INT_BLOCK_Y_COUNT);
                    imgEntity.posX = (short)((indexX - 1) * imgEntity.width);
                    imgEntity.posY = (short)((indexY - 1) * imgEntity.height);
                    if (indexX == MyConfig.INT_BLOCK_X_COUNT)
                    {
                        imgEntity.width = (short)(imgEntity.width + (screenXY[0] % MyConfig.INT_BLOCK_X_COUNT));
                    }
                    if (indexY == MyConfig.INT_BLOCK_Y_COUNT)
                    {
                        imgEntity.height = (short)(imgEntity.height + (screenXY[1] % MyConfig.INT_BLOCK_Y_COUNT));
                    }
                    //初始化一个图形操作句柄
                    Graphics screenGraphic = Graphics.FromHwnd(IntPtr.Zero);
                    //初始化一个位图 宽、 高、 分辨率，分辨率和屏幕分辨率一致
                    Bitmap screenBitmap = new Bitmap(imgEntity.width, imgEntity.height, screenGraphic);
                    //从指定的图形接口，链接到screenbitmap，以便操作位图
                    Graphics bitmapGraphics = Graphics.FromImage(screenBitmap);
                    //获取操作屏幕的句柄
                    IntPtr hdcScreen = screenGraphic.GetHdc();
                    //获取操作新建位图的句柄
                    IntPtr hdcBitmap = bitmapGraphics.GetHdc();
                    //截屏操作
                    BitBlt(hdcBitmap, 0, 0,imgEntity.width,imgEntity.height , hdcScreen,imgEntity.posX , imgEntity.posY, CopyPixelOperation.SourceCopy|CopyPixelOperation.CaptureBlt);

                    screenGraphic.ReleaseHdc(hdcScreen);
                    bitmapGraphics.ReleaseHdc(hdcBitmap);
                    screenGraphic.Dispose();
                    bitmapGraphics.Dispose();

                    ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo imgInfo = null;
                    foreach (ImageCodecInfo ici in CodecInfo)
                    {
                        if (ici.MimeType == "image/jpeg")
                        {
                            imgInfo = ici;
                        }
                    }
                    EncoderParameter p = new EncoderParameter(Encoder.Quality, MyConfig.INT_DESKTOP_QA);
                    EncoderParameters ps = new EncoderParameters(1);
                    ps.Param[0] = p;

                    //screenBitmap.Save("e:\\"+indexX+indexY+".jpg", imgInfo, ps);

                    MemoryStream mStream = new MemoryStream();
                    screenBitmap.Save(mStream, imgInfo, ps);
                    Byte[] imgBuffer = new Byte[mStream.Length];
                    mStream.Seek(0, SeekOrigin.Begin);
                    mStream.Read(imgBuffer, 0, (Int32)mStream.Length);
                    imgEntity.body = imgBuffer;
                    imgEntity.realLenth = imgBuffer.Length;
                    //Console.WriteLine("原始数据 : 第" + imgEntity.posX + "-" + imgEntity.posY + "组 ： 数据长度 "+imgEntity.body.Length+"  , 3:" + imgEntity.body[imgEntity.realLenth - 3]+" , 2: " + imgEntity.body[imgEntity.realLenth - 2]+ " , 1: "+imgEntity.body[imgEntity.realLenth - 1]);
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
