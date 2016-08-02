using System;
using System.Windows.Forms;
using ywcai.global.config;

namespace ywcai.core.veiw
{
    partial class RemoteDesk
    {
        private void registerDeskListener()
        {
            //this.deskTop.MouseClick += vClick;
            //this.deskTop.MouseDoubleClick += vDoubleClick;
            this.deskTop.MouseDown += vDown;
            this.deskTop.MouseUp += vUp;
            this.deskTop.MouseWheel += vWheel;
            this.deskTop.MouseMove += vMove;
        }

        private void vDown(object sender, MouseEventArgs e)
        {
            String cmd = "0-0-0";
            if (e.Button.ToString().Equals("Left"))
            {
                cmd = MyConfig.MOUSE_LEFT_DOWN ;
            }
            if (e.Button.ToString().Equals("Right"))
            {
                cmd = MyConfig.MOUSE_RIGHT_DOWN ;
            }
            Console.WriteLine(cmd);
            sendEvent(cmd);
        }
        private void vUp(object sender, MouseEventArgs e)
        {
            String cmd = "0-0-0";
            if (e.Button.ToString().Equals("Left"))
            {
                cmd = MyConfig.MOUSE_LEFT_UP;
            }
            if (e.Button.ToString().Equals("Right"))
            {
                cmd = MyConfig.MOUSE_RIGHT_UP;
            }
            Console.WriteLine(cmd);
            sendEvent(cmd);
        }
        private void vWheel(object sender, MouseEventArgs e)
        {
            String cmd = MyConfig.MOUSE_MID_SCROLL + "," + e.Delta ;
            sendEvent(cmd);
        }
        private void vMove(object sender, MouseEventArgs e)
        {
            String cmd = MyConfig.MOUSE_MOVE + "," + e.X + ":" + e.Y;
            sendEvent(cmd);
        }
        private void sendEvent(String cmd)
        {
            ctrlCenter.sendCmd(cmd);
        }
    }
}