// Add a custom header to outgoing requests using a custom message handler.

using System;
using System.IO;
using Aspose.Html.Net;

class CustomHeaderHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["X-Custom-Header"] = "MyValue";
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomHeaderHandler());

            // Prepare a minimal HTML file
            string inputPath = "sample.html";
            File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");

            // Load the document with the custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, "", configuration))
            {
                // Set PDF save options
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

                // Convert HTML to PDF
                string outputPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("Conversion completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}