namespace SyslogAssignment.Classes
{
  public static class GlobalConstants
  {
    public const int DEFAULT_PORT_NUM = 514;
    public const string DEFAULT_IP4_ADDRESS = "127.0.0.1";
    public static List<SyslogMessage> LiveFeedMessages = new List<SyslogMessage>();
  }
}
