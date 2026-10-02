// Add a custom header indicating conversion version to response using a version‑header handler.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class VersionHeaderHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        context.Response.Headers["X-Conversion-Version"] = "1.0";
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "sample.html";
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Output PDF path
            string outputPath = "output.pdf";

            // Configure Aspose.HTML with custom handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new VersionHeaderHandler());

            // Load HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                // Convert to PDF
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed. PDF saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}