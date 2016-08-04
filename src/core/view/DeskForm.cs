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
        public DeskForm(ControlCenter ctrlbus)
        {
            ctrl = ctrlbus;
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            ctrl.disconnectLink();
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
