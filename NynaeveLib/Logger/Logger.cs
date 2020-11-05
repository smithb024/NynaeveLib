namespace NynaeveLib.Logger
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class Logger
  {
    private static Logger instance = null;
    private static readonly object locker = new object();

    private const string logPath = ".\\log";

    /// <summary>
    /// Prevents a default instance of the <see cref="Logger"/> class from being created.
    /// </summary>
    private Logger(string logName)
    {
      LogName = logName;

      if (!Directory.Exists(logPath))
      {
        Directory.CreateDirectory(logPath);
      }

      // Create the log file name.
      FileName =
        logPath +
        Path.DirectorySeparatorChar +
        DateTime.Now.ToString("yyyyMMdd") +
        " " +
        DateTime.Now.ToLongTimeString() +
        LogName +
        ".txt";

      FileName = FileName.Replace(" ", "_");
      FileName = FileName.Replace(":", "_");

      // Create file and write header information.
      FileInfo file = new FileInfo(FileName);
      FileStream stream = file.Create();
      stream.Close();

      WriteLog("--------------------------------------");
      WriteLog(string.Format("{0} Log File", LogName));
      WriteLog("--------------------------------------");
    }

    /// <summary>
    /// Gets a new instance of the <see cref="Logger"/> class.
    /// </summary>
    public static Logger Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new Logger("namelessLog");
        }

        return instance;
      }
    }

    /// <summary>
    /// Gets or sets the name of the log file.
    /// </summary>
    private static string LogName { get; set; }

    /// <summary>
    /// Gets pr sets the name of the log file name.
    /// </summary>
    private static string FileName { get; set; }

    /// <summary>
    /// Sets the initial instance of the logger class.
    /// </summary>
    /// <remarks>
    /// Should only be called once, it creates the logger and gives it a name. If the standard
    /// instance property is called before this, then the log gets a standard name.
    /// </remarks>
    /// <param name="fileName">name of the log file.</param>
    public static  void SetInitialInstance(string fileName)
    {
      if (instance == null)
      {
        instance = new Logger(fileName);
      }
    }

    /// <summary>
    /// Writes the log entry string to the log.
    /// </summary>
    /// <param name="logEntry">entry to log.</param>
    public void WriteLog(string logEntry)
    {
      StreamWriter writer = null;

      lock (locker)
      {
        try
        {
          using (writer = File.AppendText(FileName))
          {
            writer.WriteLine(
              $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToShortDateString()}|{logEntry}");
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.ToString());
        }
      }
    }

    // <summary>
    // Open Log file
    // </summary>
    public void OpenLogFile()
    {
      System.Diagnostics.Process.Start(@FileName);
    }

    // <summary>
    // Open the log directory.
    // </summary>
    public void OpenLogDirectory()
    {
      System.Diagnostics.Process.Start(logPath);
    }
  }
}
