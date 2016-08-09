using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ywcai.core.control;

namespace ywcai.core.veiw
{
    public partial class DeskForm : Form
    {
        private ControlCenter ctrl;
        private Boolean menuFlag=true;

        public const int syscommand = 0x112;
        public const int maxbutton = 0xF030;
        public DeskForm(ControlCenter ctrlbus)
        {
            ctrl = ctrlbus;
            InitializeComponent();
            this.picbox_desk.MouseWheel +=new MouseEventHandler(picbox_desk_MouseWheel)   ; 
        }

  

        protected override void OnClosing(CancelEventArgs e)
        {
            ctrl.disconnectLink();
        }
        protected override void WndProc(ref Message m)
        {
            if(m.Msg==syscommand)
            {
                if(m.WParam.ToInt32()==maxbutton)
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    menuFlag = true;
                    bt_normal.Text = "窗口模式";
                    return ;
                }
            }
            base.WndProc(ref m);
        }


        public void draw(Bitmap img)
        {
            picbox_desk.Width = img.Width;
            picbox_desk.Height = img.Height;
            picbox_desk.Image = img;
        }
        public void setFullScreen()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; 
                this.WindowState = FormWindowState.Normal;
                hideMenu();
                menuFlag = false;
                bt_normal.Text = "全屏模式";
                return;
            }
            if (this.WindowState == FormWindowState.Normal)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                menuFlag = true;
                bt_normal.Text = "窗口模式";
                return;
            }
        }
        private void setMinScreen()
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void hideMenu()
        {
            this.pannel_ctrlmenu.Visible = false;
        }

        private void bt_hide_Click(object sender, System.EventArgs e)
        {
            hideMenu();
        }

        private void bt_min_Click(object sender, System.EventArgs e)
        {
            setMinScreen();
        }

        private void bt_normal_Click(object sender, System.EventArgs e)
        {
            setFullScreen();
        }

        private void bt_shutdown_Click(object sender, System.EventArgs e)
        {
            ctrl.disconnectLink();
        }

    }
}
