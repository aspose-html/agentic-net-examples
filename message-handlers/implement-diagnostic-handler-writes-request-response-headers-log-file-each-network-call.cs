// Implement a diagnostic handler that writes request and response headers to a log file for each network call.

public sealed class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    public LogMessageHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(_logFilePath, true))
        {
            writer.WriteLine("Request URI: " + context.Request.RequestUri);
            writer.WriteLine("Request Headers: " + System.Convert.ToString(context.Request.Headers));
            Next(context);
            writer.WriteLine("Response Status: " + context.Response.StatusCode);
            writer.WriteLine("Response Headers: " + System.Convert.ToString(context.Response.Headers));
            writer.WriteLine(new string('-', 40));
        }
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string logPath = "network_log.txt";
            string outputPath = "output.html";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LogMessageHandler(logPath));
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                document.Save(outputPath);
            }
            System.Console.WriteLine("Document saved to " + outputPath);
            System.Console.WriteLine("Network log written to " + logPath);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}