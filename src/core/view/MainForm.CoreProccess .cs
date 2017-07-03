using System;
using ywcai.core.control;
using ywcai.global.config;

namespace ywcai.core.veiw
{
    partial class RemoteDesk
    {
        private ControlCenter ctrlCenter = new ControlCenter();
        private void StartLocalService()
        {
            ctrlCenter.StartServer();
            ctrlCenter.setPsw(label_token.Text.ToString());
        }
    }
}
