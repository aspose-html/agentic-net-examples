// Implement IDisposable pattern in a custom handler to release resources after processing.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

sealed class CustomHandler : MessageHandler, IDisposable
{
    private bool _disposed;
    private readonly System.IO.MemoryStream _resource = new System.IO.MemoryStream();

    public override void Invoke(INetworkOperationContext context)
    {
        // Continue to the next handler in the pipeline
        Next(context);
    }

    private void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            // Release managed resources
            _resource.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source HTML and the output PDF
            string htmlPath = "input.html";
            string outputPath = "output.pdf";

            // Create configuration and register the custom handler
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new CustomHandler());

            // Load the HTML document with the configuration and render to PDF
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            using (PdfDevice device = new PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}