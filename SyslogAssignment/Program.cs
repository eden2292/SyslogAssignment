using System.Net.Sockets;

namespace SyslogAssignment
{
    public class UDPListeningSocket
    {
        public UDPListeningSocket()
        {
            //ListeningSocketInitialise();
        }

        private void ListeningSocketInitialisation()
        {
            
        }
        private static void Main()
        {
            SyslogMessage msg = new SyslogMessage("abc");
            msg.ParseMessage("<12345> Hello test test test");
        }
    }
}