// Batch convert a folder of HTML files to PDF, applying the same conversion options to each.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class LogHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing HTML files to convert
            string inputDir = @"C:\InputHtml";

            // Iterate over all .html files in the folder
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                // Create a configuration for each document
                Configuration configuration = new Configuration();

                // Add a network message handler for logging
                INetworkService network = configuration.GetService<INetworkService>();
                network.MessageHandlers.Add(new LogHandler());

                // Load the HTML document with the configuration
                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    // Determine output PDF path (same folder, same name with .pdf extension)
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");

                    // Set PDF conversion options (default options can be customized here)
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Convert the HTML document to PDF
                    Converter.ConvertHTML(document, options, pdfPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}