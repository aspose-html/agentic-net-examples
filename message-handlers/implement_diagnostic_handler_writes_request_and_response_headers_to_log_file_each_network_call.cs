// Implement a diagnostic handler that writes request and response headers to a log file for each network call.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string logPath = "network_log.txt";
                string inputPath = "sample.html";
                string outputPath = "output.html";

                // Create a minimal sample HTML file if it does not exist
                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>");
                }

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Add(new LogMessageHandler(logPath));

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
                {
                    document.Save(outputPath);
                }

                System.Console.WriteLine("Document saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    public sealed class LogMessageHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly string logFilePath;

        public LogMessageHandler(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(this.logFilePath, true))
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
}