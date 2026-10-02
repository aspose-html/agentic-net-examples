// Configure NetworkDisabledMessageHandler to allow only about and base64 protocols for secure offline rendering.

using System;

public sealed class AllowedProtocolsMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri))
        {
            if (!(requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase) ||
                  requestUri.StartsWith("about:", StringComparison.OrdinalIgnoreCase) ||
                  requestUri.StartsWith("data:", StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Only file, about, and data protocols are allowed.");
            }
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
            string htmlPath = "sample.html";
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new AllowedProtocolsMessageHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice("output.pdf"))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}