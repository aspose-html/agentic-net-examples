// Log errors encountered during resource download to a dedicated error log file.

using System;
using System.IO;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    public LogMessageHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine("Request URI: " + context.Request.RequestUri);
            writer.WriteLine("Request Headers: " + Convert.ToString(context.Request.Headers));
            Next(context);
            writer.WriteLine("Response Status: " + context.Response.StatusCode);
            writer.WriteLine("Response Headers: " + Convert.ToString(context.Response.Headers));
            writer.WriteLine(new string('-', 40));
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string pdfPath = Path.Combine(Path.GetTempPath(), "output.pdf");
            string logPath = Path.Combine(Path.GetTempPath(), "download_errors.log");

            // Create a minimal HTML file
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Configure Aspose.HTML and add logging handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new LogMessageHandler(logPath));

            // Load HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Render to PDF
                using (PdfDevice device = new PdfDevice(pdfPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("PDF generated at: " + pdfPath);
            Console.WriteLine("Log file created at: " + logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}