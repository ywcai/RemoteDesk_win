using System;
using System.Threading;
using System.Windows.Forms;

namespace ywcai.core.veiw
{
    public partial class LoginForm : CCWin.CCSkinMain
    {
        private delegate void UiHandler(Int32 method,String msg); //普通UI更新委托


        public LoginForm()
        {
            InitializeComponent();
        }

        private void bt_login_Click(object sender, System.EventArgs e)
        {
            
            if (checkNormal())
            {
                label_errinfo.Text = "";
                loading();
                new Thread(new ThreadStart(checkInServer)).Start();
            }
        }
        private void loading()
        {
            tx_username.ReadOnly = true;
            tx_psw.ReadOnly = true;
            bt_login.Enabled = false;
            bar_loading.Visible = true;
        }
        private void recovery()
        {
            tx_username.ReadOnly = false;
            tx_psw.ReadOnly = false;
            bt_login.Enabled = true;
            bar_loading.Visible = false;
            tx_psw.Text = "登录验证失败";
        }
        private Boolean checkNormal()
        { 
            if (tx_username.Text.Length<6|| tx_username.Text.Length>10)
            {
                label_errinfo.Text = "用户名长度为6-10位";
                return false;
            }
            if (tx_psw.Text.Length < 10 || tx_psw.Text.Length > 18)
            {
                label_errinfo.Text = "密码长度为10-18位";
                return false;
            }
            if (tx_username.Text.Contains("/,") || tx_username.Text.Contains("/.") ||tx_username.Text.Contains("/'") || tx_username.Text.Contains("//"))
            {
                label_errinfo.Text = "用户名中不允许特殊字符";
                return false;
            }
            if (tx_psw.Text.Contains("/,") || tx_psw.Text.Contains("/.") || tx_psw.Text.Contains("/'") || tx_psw.Text.Contains("//"))
            {
                label_errinfo.Text = "密码中不允许特殊字符";
                return false;
            }
            return true;
        }

        private void uiEvent(Int32 method,String msg)
        {
            if (InvokeRequired)
            {
                UiHandler uh = updateUI;
                object[] pList = {method,msg};
                //BeginInvoke(mh, pList);//异步执行了，不用加同步锁
                Invoke(uh, pList);//同步执行了
            }
            else
            {
                updateUI(method,msg);
            }
        }

        private void updateUI(Int32 method, String msg)
        {
            if (method == 2)
            {
                recovery();
            }
            if (method == 3)
            {
                changToMainForm(msg);
            }
        }
        private void reSet()
        {
            tx_username.ResetText();
            tx_psw.ResetText();
            label_errinfo.ResetText();
        }
        private void checkInServer()
        {
            //username,psw   :   sendto service 
            String token = requestServer();
            if (token.Equals(""))
            {
                uiEvent(2, token);
            }
            else
            {
                uiEvent(3,token);
            }
        }
        private String requestServer()
        {
            String token = "ywcai12345678900";
            //访问服务器，验证账号密码
            Thread.Sleep(1000);
            return token;
        }

        private void changToMainForm(String token)
        {
            TransferInfo info = new TransferInfo();
            info.token = token;
            info.username = tx_username.Text;
            Thread newForm = new Thread(new  ParameterizedThreadStart(activeForm));
            newForm.SetApartmentState(ApartmentState.STA);
            newForm.IsBackground = false;
            newForm.Start(info);
            this.recovery();
            this.Dispose(true);
        }
        private class TransferInfo
        {
            public String username, token;
        }
        private void activeForm(Object info)
        {
            String username = ((TransferInfo)info).username;
            String token = ((TransferInfo)info).token;
            Application.Run(new RemoteDesk(username, token));
        }
    }
}
