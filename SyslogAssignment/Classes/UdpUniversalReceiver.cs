using System.Net;
using System.Net.Sockets;
using System.Text;
using static SyslogAssignment.Classes.GlobalConstants;
namespace SyslogAssignment.Classes
{
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

    public async void StartListening() //we need to have a stop listening and we also need a way to listen on local host
    {
      _continue = true;
      while (_continue)
      {
        UdpReceiveResult _waitingToReceiveMessage = await LocalClient.ReceiveAsync();
        byte[] _receivedMessage = _waitingToReceiveMessage.Buffer;
        IPEndPoint _sourceInformation = _waitingToReceiveMessage.RemoteEndPoint;
      }
    }
    public async void StopListening()
    {
      await Task.Run( () => _continue = false);
    }
  }
}
