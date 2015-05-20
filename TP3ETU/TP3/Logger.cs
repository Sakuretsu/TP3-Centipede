//<Charles Lachance>
using System;
using System.IO;

namespace TP3
{
  class Logger
  {
    private static Logger logger = null;

    private Logger()
    {
      
    }

    public static Logger GetInstance()
    {
      if (logger == null)
        logger = new Logger();
      return logger;
    }

    public void Log(string text)
    {
      try
      {
        File.AppendAllText("log.txt", DateTime.Now.ToString() + ":\t" + text + "\r\n");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Logger : " + ex.Message);
        Console.WriteLine(text);
      }
    }

    public void EndLog(string text)
    {
      try
      {
        File.AppendAllText("log.txt", DateTime.Now.ToString() + ":\t" + text + "\r\n");
        File.AppendAllText("log.txt", "---------------------------------------------\r\n");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Logger : " + ex.Message);
        Console.WriteLine(text);
      }
    }
  }
}
//</Charles Lachance>