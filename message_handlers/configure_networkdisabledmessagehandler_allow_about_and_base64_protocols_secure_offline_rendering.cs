// Configure NetworkDisabledMessageHandler to allow only about and base64 protocols for secure offline rendering.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class AboutBase64MessageHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) &&
            !(requestUri.StartsWith("about:", StringComparison.OrdinalIgnoreCase) ||
              requestUri.StartsWith("data:", StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Only about and base64 (data) protocols are allowed.");
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Configure Aspose.HTML with the custom network handler
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new AboutBase64MessageHandler());

            // Load an HTML document (replace with your actual file path)
            string htmlPath = "sample.html";
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // Render the document to PDF (replace with your desired output path)
                string outputPdf = "output.pdf";
                using (PdfDevice device = new PdfDevice(outputPdf))
                {
                    document.RenderTo(device);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}