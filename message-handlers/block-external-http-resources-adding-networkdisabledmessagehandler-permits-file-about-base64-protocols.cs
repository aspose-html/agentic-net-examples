// Block external HTTP resources by adding a NetworkDisabledMessageHandler that permits file, about, and base64 protocols.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Output PDF path
            string outputPath = "output.pdf";

            // Configure Aspose.HTML with the custom network handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Load the HTML document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Network handler that blocks external HTTP resources, allowing only file, about, and base64 protocols
public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();

        if (!string.IsNullOrEmpty(requestUri) &&
            !(requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase) ||
              requestUri.StartsWith("about:", StringComparison.OrdinalIgnoreCase) ||
              requestUri.StartsWith("data:", StringComparison.OrdinalIgnoreCase) ||
              requestUri.StartsWith("base64:", StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Only file, about, and base64 resources are allowed.");
        }

        Next(context);
    }
}