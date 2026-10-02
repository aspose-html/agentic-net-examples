// Log errors encountered during resource download to a dedicated error log file.

using System;
using System.IO;
using System.Net;

public sealed class FileErrorLogHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    public FileErrorLogHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Proceed with the request
        Next(context);

        // Log only if the response indicates an error
        if (context.Response.StatusCode != HttpStatusCode.OK)
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine("Error downloading resource:");
                writer.WriteLine("Request URI: " + context.Request.RequestUri);
                writer.WriteLine("Response Status: " + context.Response.StatusCode);
                writer.WriteLine(new string('-', 40));
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare sample HTML with an invalid external resource
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Test</title></head>
<body>
<h1>Sample Document</h1>
<img src=""http://nonexistent.example.com/image.jpg"" alt=""Missing Image"" />
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Define log file path
            string logPath = Path.Combine(Path.GetTempPath(), "error.log");

            // Configure Aspose.HTML with custom network handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new FileErrorLogHandler(logPath));

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Render to PDF to trigger resource download
                string outputPdf = Path.Combine(Path.GetTempPath(), "output.pdf");
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdf))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("Processing completed. Check the log file for any download errors:");
            Console.WriteLine(logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}