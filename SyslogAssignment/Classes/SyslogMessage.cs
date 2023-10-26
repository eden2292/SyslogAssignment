using System;

public class SyslogMessage
{
	private UInt16 Severtiy { get; set; }
	private DateTime DateTime { get; set; }
	private string MessageContent { get; set; }
	private string FullMessage { get; set; }
	public SyslogMessage(string fullMessage)
	{
		FullMessage = fullMessage;
		ParseMessage(fullMessage);
	}

	/// <summary>
	/// Parses text Syslog messages into a Message object
	/// </summary>
	/// <param name="fullMessage">The full Syslog message</param>
	/// <returns>Boolean for if the parse is successful</returns>
	public bool ParseMessage(string fullMessage)
	{
		//This will need to be restructured as return statements must be at the end of a method
        UInt16 severity = 0;

        if (fullMessage[0] != '<')
			return false;

		int endArrowPosition = 1;
		for ( ; ; endArrowPosition++ )
		{
			if (fullMessage[endArrowPosition] == '>')
				break;
				
			if (!Char.IsDigit(fullMessage[endArrowPosition]))
				return false;
			
		}

		string severityString = fullMessage.Substring(1, (endArrowPosition - 1));
		//severity = 

		return true;
	}
}
