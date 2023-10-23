using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace SyslogAssignment.Sockets;

public class UDPListeningSocket
{
  private Socket _UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

  private static IPAddress s_t6s3IPAddress = IPAddress.Parse("177.168.1.233");

  private IPEndPoint UDPEndPoint = new IPEndPoint(s_t6s3IPAddress, 514);
  
  while(true)
  {
    String text = "hello";
    byte[] send_buffer = Encoding.ASCII.GetBytes(text);
    
    _UDPSocket SendTo(send_buffer, IPEndPoint);
    Console.WriteLine($"Sending on {s_t6s3IPAddress}");
  }
  
}