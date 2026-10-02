// Log detailed extraction steps to a file using Serilog for troubleshooting purposes.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string logPath = "extraction.log";
        try
        {
            // Initialize log file
            File.AppendAllText(logPath, "=== Extraction started at " + DateTime.Now + " ===" + Environment.NewLine);

            // Create a minimal HTML file with images
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<img src='image1.png' />
<img src='image2.jpg' />
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);
            File.AppendAllText(logPath, "Created sample HTML file: " + htmlPath + Environment.NewLine);

            // Configure Aspose.HTML with a custom network logger (optional for file loading)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeLoggerMessageHandler(logPath));
            File.AppendAllText(logPath, "Configured network service with custom logger." + Environment.NewLine);

            // Load the HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlPath, configuration);
            File.AppendAllText(logPath, "Loaded HTML document from: " + htmlPath + Environment.NewLine);

            // Evaluate XPath to select all img elements
            Aspose.Html.Dom.XPath.IXPathResult xpathResult = doc.Evaluate(
                "//img",
                doc,
                doc.CreateNSResolver(doc),
                Aspose.Html.Dom.XPath.XPathResultType.Any,
                null);
            File.AppendAllText(logPath, "Executed XPath query: //img" + Environment.NewLine);

            // Iterate over results and log each image source
            Aspose.Html.Dom.Node node;
            while ((node = xpathResult.IterateNext()) != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)node;
                File.AppendAllText(logPath, "Found image src: " + img.Src + Environment.NewLine);
            }

            // Optionally save the document to a new file
            string outputPath = "output.html";
            doc.Save(outputPath);
            File.AppendAllText(logPath, "Saved document to: " + outputPath + Environment.NewLine);

            File.AppendAllText(logPath, "=== Extraction completed successfully ===" + Environment.NewLine);
        }
        catch (Exception ex)
        {
            File.AppendAllText(logPath, "Error: " + ex.Message + Environment.NewLine);
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

// Custom message handler for detailed network logging
public sealed class TimeLoggerMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFile;
    public TimeLoggerMessageHandler(string logFilePath)
    {
        _logFile = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (var writer = new StreamWriter(_logFile, true))
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