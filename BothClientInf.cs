namespace ywcai.core.control
{
    interface BothClientInf
    {
        void loginIn(string username,string nickname);
        void loginEnd(string username,string result);
        void loginOut(string nickname);
        void loginOutEnd( string result);
        void createLink(string index);
        void createEnd(string result);
        void disconnectLink();
        void disconnectEnd(string result);
        void updateLists(string lists);
        void dataProccess(byte tag, string username,byte[] buf);
    }
}
