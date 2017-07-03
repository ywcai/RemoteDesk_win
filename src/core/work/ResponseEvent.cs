using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ywcai.core.control
{
    public class ResponseEvent
    {

        private  const int INT_MOVE_DGREEN = 1;
        private  const int INT_SCEREEN_X = 1366, INT_SCEREEN_Y = 768;
        [Flags]
        enum MouseEventFlag : int
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            Absolute = 0x8000
        }
        [DllImport("user32.dll")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        private static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public static void ReponseClick(String clickEvent)
        {
            switch (clickEvent)
            {
                case "left_up":
                    mouse_event((Int32)MouseEventFlag.LeftUp, 0, 0, 0, 0);
                    break;
                case "left_down":
                    mouse_event((Int32)MouseEventFlag.LeftDown, 0, 0, 0, 0);
                    break;
                case "right_up":
                    mouse_event((Int32)MouseEventFlag.RightUp, 0, 0, 0, 0);
                    break;
                case "right_down":
                    mouse_event((Int32)MouseEventFlag.RightDown, 0, 0, 0, 0);
                    break;
                case "esc":
                    keybd_event(Keys.Escape, 0, 0, 0);
                    keybd_event(Keys.Escape, 0, 2, 0);
                    break;
                case "page_up":
                    keybd_event(Keys.PageUp, 0, 0, 0);
                    keybd_event(Keys.PageUp, 0, 2, 0);
                    break;
                case "page_down":
                    keybd_event(Keys.PageDown, 0, 0, 0);
                    keybd_event(Keys.PageDown, 0, 2, 0);
                    break;
            }
        }
        public static void ReponseMove(int p_x, int p_y)
        {
            int _x, _y;
            int intToX, intToY;
            int intFactor;
            int intAbsX;
            int intAbsY;
            int intRate, intMod;
            int intAbsMax, intAbsMin;
            int intSigeX, intSigeY;
            int intClearNode;
            int intStepMaxX, intStepMaxY;
            int intStepMinX, intStepMinY;
            _x = -p_x;
            _y = -p_y;

            //如果一次移动为1366px或者768px，则么次移动pos/((1366/pos)+1)；
            //如果一次移动为2px，则次移动1px；


            //获取默认移动补间动画的比例；初始为1。既移动按1px进行递增。
            intFactor = INT_MOVE_DGREEN;

            //中弧度轨迹
            intToX = _x * INT_SCEREEN_X /1800 ;
            intToY = _y * INT_SCEREEN_Y /1200 ;

            if(Math.Abs(_x)>600)
            {
                //大弧度轨迹
                intToX = _x * INT_SCEREEN_X / 600;

            }
            if (Math.Abs(_x) < 100)
            {
                //小弧度轨迹
                intToX = _x * INT_SCEREEN_X / 3600;
            }

            if (Math.Abs(_y) > 450)
            {
                intToY = _y * INT_SCEREEN_Y / 450;
            }
            if (Math.Abs(_y) < 80)
            {
                intToY = _y * INT_SCEREEN_Y / 2400;
            }
            intAbsX = Math.Abs(intToX); //求X轴的绝对值
            intAbsY = Math.Abs(intToY); //求Y轴的绝对值
            intSigeX = intToX != 0 ? (intAbsX / intToX) : 0;//求X轴的符号；
            intSigeY = intToY != 0 ? (intAbsY / intToY) : 0;//求Y轴的符号；
            intAbsMax = intAbsX >= intAbsY ? intAbsX : intAbsY;//求长轴的绝对值；
            intAbsMin = intAbsX <= intAbsY ? intAbsX : intAbsY;//求短轴的绝对值；
            intRate = intAbsMin != 0 ? (intAbsMax / intAbsMin) : (intAbsMax + 1); //求坡度 ， 若短轴为0，则给坡度赋予一个永远不被intAbsMax整除的值，使下面代码只运行长轴上的值；
            intMod = intAbsMin != 0 ? (intAbsMax % intAbsMin) : 0;//求长短轴的余数。若小的轴为0，则余数0，使用   if (n % intClearNode == 0)下面的代码也永远不被运行；
            intStepMaxX = intAbsX >= intAbsY ? intSigeX : 0;//若果长的轴为X，则值为( intSigeX,0)，
            intStepMaxY = intAbsX >= intAbsY ? 0 : intSigeY;//若果长的轴为X，则值为(0, intSigeY)，
            intStepMinX = intAbsX <= intAbsY ? intSigeX : 0; //若果短的轴为Y，则值为( intSigeX,0)，
            intStepMinY = intAbsX <= intAbsY ? 0 : intSigeY; //若果短的轴为Y，则值为( 0,intSigeY)

            intClearNode = intMod != 0 ? (intAbsMax / intMod) : (intAbsMax + 1);//如果X与Y轴不能整除， 则计算出处理余数的节点位置。能整除，则赋值(intAbsMax+1），让他永远不能被小于等于intAbsMax的数整除，是下面清理余数的代码不会被触发。

            //计算增长英子  (1366/n)+2；
            if (intAbsX >= (INT_SCEREEN_X / 2) || intAbsY >= (INT_SCEREEN_Y / 2))
            {
                intFactor = intAbsMax / 20;
                //  Console.WriteLine("faster");
            }
            else if (intAbsX >= (INT_SCEREEN_X / 5) || intAbsY >= (INT_SCEREEN_Y / 6))
            {
                intFactor = intAbsMax / 40;
                //  Console.WriteLine("normal");
            }
            else
            {
                intFactor = INT_MOVE_DGREEN;
                //   Console.WriteLine("low");
            }

            for (int n = 1; (n * intFactor) <= intAbsMax; n++)
            {
                if (n % intRate == 0 && intRate != 0)
                {
                    //n在rate的整除点位， 长、短两轴同时位移1；
                    StepMove((intStepMaxX + intStepMinX) * intFactor, (intStepMaxY + intStepMinY) * intFactor);
                }
                else
                {
                    //n不在rate的整除点位，长轴单独移动；
                    StepMove(intStepMaxX * intFactor, intStepMaxY * intFactor);
                }
                //若长轴处理完成仍有余数，将余数平均分解MAX的大小在结束之前进行均分处理。
                if (n % intClearNode == 0)
                {
                    //处理余数;将余数均匀分解处理。
                    StepMove(intStepMaxX * intFactor, intStepMaxY * intFactor);//长轴自加
                }
            }
        }

        private static void StepMove(int p_x, int p_y)
        {
            mouse_event((Int32)MouseEventFlag.Move, p_x, p_y, 0, 0);
        }


    }
}
