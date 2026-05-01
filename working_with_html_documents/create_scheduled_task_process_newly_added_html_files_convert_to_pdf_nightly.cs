// Create a scheduled task that processes newly added HTML files, converting them to PDF nightly.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Services;
using Aspose.Html.Net;

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
            // Folder containing HTML files to be processed
            string inputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HtmlFiles");

            // Ensure the folder exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine($"Input directory does not exist: {inputDir}");
                return;
            }

            // Process each HTML file in the folder
            foreach (string htmlPath in Directory.GetFiles(inputDir, "*.html"))
            {
                // Create a configuration for each conversion
                Configuration configuration = new Configuration();

                // Add a logging handler to monitor network operations (optional)
                INetworkService network = configuration.GetService<INetworkService>();
                network.MessageHandlers.Add(new LogHandler());

                // Load the HTML document with the configuration
                using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
                {
                    // Determine the output PDF path (same name, .pdf extension)
                    string pdfPath = Path.ChangeExtension(htmlPath, ".pdf");

                    // Set PDF conversion options (default settings)
                    PdfSaveOptions options = new PdfSaveOptions();

                    // Perform the conversion
                    Converter.ConvertHTML(document, options, pdfPath);

                    Console.WriteLine($"Converted: {Path.GetFileName(htmlPath)} -> {Path.GetFileName(pdfPath)}");
                }
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}