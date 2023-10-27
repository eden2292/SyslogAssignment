using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public class SyslogMessage
{
  private byte Priority { get; set; } // The priority number which we can derive the facility and severity from
  private byte Facility
  { get { return 0; } } // Placeholder for the formula
	private byte Severtiy
  { get { return 0; } } // Placeholder for the formula
  private string SenderIP;
	private DateTimeOffset? SentDateTime { get; set; } // The date/time in the syslog message itself, can be null if the format in the syslog message fails to parse
  private DateTimeOffset ReceivedDateTime { get; set; } // The date/time when the message was received, using .NET DateTime.Now when the remote store gets the message
	private string FullMessage { get; set; } // The full syslog message
	public SyslogMessage(string senderIp, DateTime receivedDateTime, string fullMessage)
	{
    SenderIP = senderIp;
    ReceivedDateTime = receivedDateTime;
		FullMessage = fullMessage;
	}


  /// <summary>
  /// Parses text Syslog messages into a Message object
  /// </summary>
  /// <param name="fullMessage">The full Syslog message</param>
  /// <returns>Boolean for if the parse is successful</returns>
  public bool ParseMessage(string fullMessage)
  {
    bool messageParsedSuccessfully = false;

    if(fullMessage[0] == '<')
      messageParsedSuccessfully = ParseEndArrowPosition(fullMessage);

    // Only the priority needs to be parsed, the version and date/time is optional

    return messageParsedSuccessfully;
  }

  private bool ParseEndArrowPosition(string fullMessage)
  {
    bool messageParsedSuccessfully = false;

    for(int endArrowPosition = 1; ; endArrowPosition++)
    {
      if(endArrowPosition == 5) // Facility's numerical code can only be 3 digits at most so return false if there's more
        break;

      if(fullMessage[endArrowPosition] == '>')
        messageParsedSuccessfully = ParsePriority(fullMessage, endArrowPosition);

      if(!Char.IsDigit(fullMessage[endArrowPosition]))
        break;

    }

    return messageParsedSuccessfully;
  }

  private bool ParsePriority(string fullMessage, int endArrowPosition)
  {
    bool messageParsedSuccessfully = false;

    byte priority = 0;
    string priorityString = fullMessage.Substring(1, (endArrowPosition - 1));
    if (priorityString.Length > 0)
      priority = byte.Parse(priorityString);
    else
      priority = 0;

    if(priority < 192)
    {
      // At this point we have determined that the syslog message has parsed successfully and do not need to worry about whether or not further parsing is successful
      // The program will try to parse the date and time in the syslog message, and if it is unsuccessful, it will NOT affect the returned boolean of the ParseMessage() method
      messageParsedSuccessfully = true;
      Priority = priority;
      ParseSyslogVersion(fullMessage, endArrowPosition);
    }

    return messageParsedSuccessfully;
  }

  private bool ParseSyslogVersion(string fullMessage, int endArrowPosition)
  {
    bool dateTimeParsedSuccessfully = false;

    for(int versionSpacePosition = endArrowPosition + 1; ;  versionSpacePosition++)
    {
      if(versionSpacePosition == endArrowPosition + 3)
        break;

      if(fullMessage[versionSpacePosition] == ' ')
      {
        string dateTimeString = fullMessage.Substring(versionSpacePosition + 1);
        dateTimeParsedSuccessfully = ParseDateTime(dateTimeString);
      }

      if(!Char.IsDigit(fullMessage[versionSpacePosition]))
        break;
    }

    return dateTimeParsedSuccessfully;
  }

  private bool ParseDateTime(string syslogMessageFromDateTime)
  {
    bool dateTimeParsedSuccessfully = false;

    string dateTimeString;
    for(int dateTimeSpacePosition = 0; ; dateTimeSpacePosition++)
    {
      if(syslogMessageFromDateTime[dateTimeSpacePosition] == ' ')
      {
        dateTimeString = syslogMessageFromDateTime.Substring(0, dateTimeSpacePosition);
        break;
      }
    }

    DateTimeOffset sentDateTime;
    dateTimeParsedSuccessfully = DateTimeOffset.TryParseExact(dateTimeString, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.None, out sentDateTime);
    SentDateTime = sentDateTime;

    return dateTimeParsedSuccessfully;
  }
}
