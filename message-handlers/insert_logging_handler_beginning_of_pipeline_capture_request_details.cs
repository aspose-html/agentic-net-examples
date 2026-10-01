// Insert a logging handler at the beginning of the pipeline to capture request details.

public sealed class RequestLoggingMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string logFilePath;
    public RequestLoggingMessageHandler(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilePath, true))
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string logPath = "request_log.txt";
            string htmlPath = "sample.html";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new RequestLoggingMessageHandler(logPath));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                System.Console.WriteLine("Document saved to " + outputPath);
            }

            if (System.IO.File.Exists(logPath))
            {
                System.Console.WriteLine("Log entries:");
                foreach (string line in System.IO.File.ReadAllLines(logPath))
                {
                    System.Console.WriteLine(line);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}