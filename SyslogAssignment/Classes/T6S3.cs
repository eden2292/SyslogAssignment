using Microsoft.AspNetCore.Components.Forms;

namespace SyslogAssignment.Classes;

/// <summary>
/// Object of T6S3 radio containing relevant information for sockets. 
/// </summary>
public class T6S3 : IRadio
{
  private const int DEFAULT_PORT_NUM = 514;
  private const string DEFAULT_IP4_ADDRESS = "127.0.0.1";
  private string? _ip4Address { get; }
  private string? _ip6Address { get; }
  private int _portNumber { get; }

  public T6S3()
  {
    _portNumber = DEFAULT_PORT_NUM;
    _ip4Address = DEFAULT_IP4_ADDRESS;
  }
}