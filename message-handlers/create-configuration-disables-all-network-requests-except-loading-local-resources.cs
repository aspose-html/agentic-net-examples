// Create a configuration that disables all network requests except those required for loading local resources.

using System;

namespace AsposeHtmlNetworkExample
{
    public sealed class LocalOnlyHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
            if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", System.StringComparison.OrdinalIgnoreCase))
                throw new System.InvalidOperationException("Only local file resources are allowed.");
            Next(context);
        }
    }

    public class Program
    {
        public static void Main()
        {
            try
            {
                // Create a minimal local HTML file
                string htmlPath = "sample.html";
                if (!System.IO.File.Exists(htmlPath))
                {
                    System.IO.File.WriteAllText(htmlPath,
                        "<!DOCTYPE html><html><head><title>Test Document</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                }

                // Configure Aspose.HTML to allow only local resources
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Insert(0, new LocalOnlyHandler());

                // Load the local HTML document using the custom configuration
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    // Output the document title to verify successful loading
                    Console.WriteLine("Document title: " + document.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}