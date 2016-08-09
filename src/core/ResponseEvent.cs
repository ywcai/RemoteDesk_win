using System;

using System.Runtime.InteropServices;

using ywcai.global.config;

namespace ywcai.core.control
{
    class ResponseEvent
    {
        [DllImport("user32.dll")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

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

        public  static void exeEvent(String cmd)
        {
            String[] query = cmd.Split(',');
            String[] pos = query[1].Split(':');
            Int32 x = Int32.Parse(pos[0]);
            Int32 y = Int32.Parse(pos[1]);
            switch (query[0])
            {
                case MyConfig.MOUSE_LEFT_UP:
                    leftUp(x, y);
                    break;
                case MyConfig.MOUSE_RIGHT_UP:
                    rightUp(x, y);
                    break;
                case MyConfig.MOUSE_LEFT_DOWN:
                    leftDown(x, y);
                    break;
                case MyConfig.MOUSE_RIGHT_DOWN:
                    rightDown(x, y);
                    break;
                case MyConfig.MOUSE_MID_SCROLL:
                    wheelScroll(x);
                    break;
                case MyConfig.MOUSE_MOVE:
                    move(x,y);
                    break;
                default:
                    //无效指令
                    break;
            }
        }

        private static void leftDown(int x, int y)
        {
            mouse_event((Int32)MouseEventFlag.LeftDown , 0, 0, 0, 0);

        }
        private static void rightDown(int x, int y)
        {
            mouse_event((Int32)MouseEventFlag.RightDown, 0, 0, 0, 0);
     
        }
        private static void leftUp(int x, int y)
        {
            mouse_event((Int32)MouseEventFlag.LeftUp, 0, 0, 0, 0);
         
        }
        private static void rightUp(int x, int y)
        {
            mouse_event((Int32)MouseEventFlag.RightUp  , 0, 0, 0, 0);
          
        }
        private static void move(int x, int y)
        {
            mouse_event((Int32)MouseEventFlag.Move| (Int32)MouseEventFlag.Absolute, x*65535/1366, y * 65535 / 768, 0, 0);
            //Console.WriteLine(x + ":" + y);
        }
        private static void wheelScroll(int delta)
        {
            mouse_event((Int32)MouseEventFlag.Wheel, 0, 0, delta, 0);
            Console.WriteLine("wheelScroll " + delta);
        }
    }
}
