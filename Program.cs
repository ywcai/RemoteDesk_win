using System;
using System.Windows.Forms;

namespace ywcai.core.veiw
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new RemoteDesk());
             Application.Run(new LoginForm());
        }
    }
}
