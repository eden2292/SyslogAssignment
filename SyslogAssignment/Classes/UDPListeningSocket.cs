using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.Hosting.Server.Features;
using static SyslogAssignment.Classes.GlobalConstants;

namespace SyslogAssignment.Classes
{

  public class UDPListeningSocket : IListeningSocket
  {
    public T6S3 ListeningRadio { get; set; }
    public UDPListeningSocket(T6S3 listeningRadio)
    {
      ListeningRadio = listeningRadio;
    }

    public bool BeginListening()
    {
      bool _hasBegun = false;
      UdpClient _udpListener = new UdpClient(ListeningRadio.PortNumber);

      IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ListeningRadio.Ip4Address), ListeningRadio.PortNumber);
      byte[] _receivedBytes = _udpListener.Receive(ref endPoint);

    }

    public bool EndListening() 
    {
    
    }
  
  }
}