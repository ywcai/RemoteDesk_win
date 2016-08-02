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
            switch (query[0])
            {
                case MyConfig.MOUSE_LEFT_UP:
                    leftUp();
                    break;
                case MyConfig.MOUSE_RIGHT_UP:
                    rightUp();
                    break;
                case MyConfig.MOUSE_LEFT_DOWN:
                    leftDown();
                    break;
                case MyConfig.MOUSE_RIGHT_DOWN:
                    rightDown();
                    break;
                case MyConfig.MOUSE_MID_SCROLL:
                    Int32 z = Int32.Parse(query[1]);
                    wheelScroll(z);
                    break;
                case MyConfig.MOUSE_MOVE:
                    String[] pos = query[1].Split(':');
                    Int32  x = Int32.Parse(pos[0]);
                    Int32  y = Int32.Parse(pos[1]);
                    move(x,y);
                    break;
                default:
                    //无效指令
                    break;
            }
        }

        private static void leftDown()
        {
            mouse_event((Int32)MouseEventFlag.LeftDown , 0, 0, 0, 0);
            Console.WriteLine("LeftDown ");
        }
        private static void rightDown()
        {
            mouse_event((Int32)MouseEventFlag.RightDown, 0, 0, 0, 0);
            Console.WriteLine("RightDown ");
        }
        private static void leftUp()
        {
            mouse_event((Int32)MouseEventFlag.LeftUp , 0, 0, 0, 0);
            Console.WriteLine("LeftUp ");
        }
        private static void rightUp()
        {
            mouse_event((Int32)MouseEventFlag.RightUp , 0, 0, 0, 0);
            Console.WriteLine("RightUp ");
        }
        private static void move(int x, int y)
        {
            mouse_event((Int32)MouseEventFlag.Move | (Int32)MouseEventFlag.Absolute, x, y, 0, 0);
        }
        private static void wheelScroll(int delta)
        {
            mouse_event((Int32)MouseEventFlag.Wheel, 0, 0, delta, 0);
            Console.WriteLine("wheelScroll " + delta);
        }
    }
}
