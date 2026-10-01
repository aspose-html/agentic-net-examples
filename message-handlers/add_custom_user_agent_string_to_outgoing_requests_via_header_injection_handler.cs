// Add a custom user‑agent string to outgoing requests via a header‑injection handler.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomUserAgentHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["User-Agent"] = "MyCustomUserAgent/1.0";
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "", configuration))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("Conversion completed: " + Path.GetFullPath(outputPath));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}