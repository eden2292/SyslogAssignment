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
      SyslogMessage msg = new SyslogMessage("192.168.1.3", DateTime.Now, "<124>1 2023-10-26T09:55:01.582Z Park Air Systems LTD test app ABCDEFGHIJKLMNOP");
      msg.ParseMessage();
    }
  }
}