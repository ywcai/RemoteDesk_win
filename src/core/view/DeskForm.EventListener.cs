using System;
using System.Windows.Forms;
using ywcai.global.config;

namespace ywcai.core.veiw
{
    partial class DeskForm
    {
        private void picbox_desk_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            String cmd = "";
            if (e.Button.ToString().Equals("Left"))
            {
                cmd = MyConfig.MOUSE_LEFT_DOWN;
            }
            if (e.Button.ToString().Equals("Right"))
            {
                cmd = MyConfig.MOUSE_RIGHT_DOWN;
            }
            cmd = cmd + "," + e.X + ":" + e.Y;
            sendEvent(cmd);
        }
        private void picbox_desk_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            String cmd = MyConfig.MOUSE_MOVE + "," + e.X + ":" + e.Y;
            if(e.X>pannel_ctrlmenu.Left&&e.Y<= 1&& menuFlag)
            {
                pannel_ctrlmenu.Show();
            }
            sendEvent(cmd);
        }

        private void picbox_desk_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
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
            cmd = cmd + "," + e.X + ":" + e.Y;
            sendEvent(cmd);
        }

        private void picbox_desk_MouseWheel(object sender, MouseEventArgs e)
        {
            String cmd = MyConfig.MOUSE_MID_SCROLL+","+e.Delta+":0";
            sendEvent(cmd);
        }


        private void sendEvent(String cmd)
        {
            //ctrl.sendCmd(cmd);
        }
    }
}