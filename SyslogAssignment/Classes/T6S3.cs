using Microsoft.AspNetCore.Components.Forms;
using static SyslogAssignment.Classes.GlobalConstants;

namespace SyslogAssignment.Classes;

/// <summary>
/// Object of T6S3 radio containing relevant information for sockets. 
/// </summary>
public class T6S3
{
  
  public string? Ip4Address { get; set; }
 // public string? Ip6Address { get; set; }
  public int PortNumber { get; set; }

  public T6S3()
  {
    PortNumber = DEFAULT_PORT_NUM;
    Ip4Address = DEFAULT_IP4_ADDRESS;
  }
}