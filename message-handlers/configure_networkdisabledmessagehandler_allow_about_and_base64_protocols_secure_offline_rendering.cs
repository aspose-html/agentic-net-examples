// Configure NetworkDisabledMessageHandler to allow only about and base64 protocols for secure offline rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class ProtocolAllowedMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri))
        {
            bool allowed = requestUri.StartsWith("file:", System.StringComparison.OrdinalIgnoreCase) ||
                           requestUri.StartsWith("about:", System.StringComparison.OrdinalIgnoreCase) ||
                           requestUri.StartsWith("base64:", System.StringComparison.OrdinalIgnoreCase);
            if (!allowed)
                throw new System.InvalidOperationException("Only file, about, and base64 protocols are allowed.");
        }
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.pdf";

            // Create a minimal HTML file
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure Aspose.HTML with custom network handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new ProtocolAllowedMessageHandler());

            // Load the document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}