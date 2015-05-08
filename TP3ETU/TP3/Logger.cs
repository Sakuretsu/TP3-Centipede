using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        File.AppendAllText("log.txt", DateTime.Now.ToString() + "\t-" + text + "\r\n");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Logger : " + ex.Message);
      }
    }

    public void EndLog(string text)
    {
      try
      {
        File.AppendAllText("log.txt", DateTime.Now.ToString() + "\t-" + text + "\r\n");
        File.AppendAllText("log.txt", "---------------------------------------------\r\n");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Logger : " + ex.Message);
      }
    }
  }
}
