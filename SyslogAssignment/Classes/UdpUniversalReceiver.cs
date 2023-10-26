using System.Net;
using System.Net.Sockets;
using System.Text;
using static SyslogAssignment.Classes.GlobalConstants;
namespace SyslogAssignment.Classes
{
  /// <summary>
  /// Listens to all pings to the local host
  /// </summary>
  public class UdpUniversalReceiver
  {
    public UdpClient LocalClient { get; set; }
    public IPAddress LocalHostIpAddress { get; set; }
    private bool _continue;

    public UdpUniversalReceiver(string IpAddress = DEFAULT_IP4_ADDRESS, int portNumber = DEFAULT_PORT_NUM) 
    {
      LocalClient = new UdpClient(portNumber);

      LocalHostIpAddress = IPAddress.Parse(IpAddress);


    }

    public async void StartListening()
    {
      _continue = true;
      while (_continue)
      {
        UdpReceiveResult _waitingToReceiveMessage = await LocalClient.ReceiveAsync();
        byte[] _receivedMessage = _waitingToReceiveMessage.Buffer;
        IPEndPoint _sourceInformation = _waitingToReceiveMessage.RemoteEndPoint;
        if (_continue)
        {
          Console.WriteLine();
        } 
      }
    }
    public async void StopListening()
    {
      await Task.Run( () => _continue = false);
    }
  }
}
