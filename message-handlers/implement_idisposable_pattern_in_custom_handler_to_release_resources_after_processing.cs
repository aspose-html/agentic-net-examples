// Implement IDisposable pattern in a custom handler to release resources after processing.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.html");
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pdf");

                if (!System.IO.File.Exists(htmlPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
                    System.IO.File.WriteAllText(htmlPath, sampleHtml);
                }

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new CustomHandler());

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                System.Console.WriteLine("PDF generated at: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    sealed class CustomHandler : Aspose.Html.Net.MessageHandler, System.IDisposable
    {
        private bool disposed;
        private readonly System.IO.MemoryStream resource = new System.IO.MemoryStream();

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            Next(context);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                resource.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}