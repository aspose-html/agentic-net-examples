// Develop a batch conversion tool that reads HTML files from a directory, applies logging handlers, and saves PDFs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

// Custom network message handler that logs request URI and response status code
class LoggingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Directory containing HTML files to convert
            string inputDir = @"C:\InputHtml";

            // Process each HTML file in the directory
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                // Create a configuration and attach the logging handler
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new LoggingHandler());

                // Load the HTML document with the configured environment
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    // Determine output PDF path
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");

                    // Set PDF conversion options (default settings)
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                    // Convert HTML to PDF
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any errors that occur during processing
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}