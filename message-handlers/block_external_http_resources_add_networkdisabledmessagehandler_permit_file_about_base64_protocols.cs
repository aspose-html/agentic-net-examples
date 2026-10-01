// Block external HTTP resources by adding a NetworkDisabledMessageHandler that permits file, about, and base64 protocols.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri))
        {
            bool allowed =
                requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase) ||
                requestUri.StartsWith("about:", StringComparison.OrdinalIgnoreCase) ||
                requestUri.StartsWith("base64:", StringComparison.OrdinalIgnoreCase);
            if (!allowed)
                throw new InvalidOperationException("Only file, about, and base64 protocols are allowed.");
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

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            using (PdfDevice device = new PdfDevice(outputPath))
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