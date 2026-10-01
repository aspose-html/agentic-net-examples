// Override Invoke method to forward request to next handler unless condition triggers short‑circuit.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom handler
            network.MessageHandlers.Add(new CustomHandler());

            // Create a minimal HTML file
            string inputPath = "sample.html";
            System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");

            // Load the document using the custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                Console.WriteLine("Document loaded. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that short‑circuits requests containing a specific substring
class CustomHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string uriText = context.Request.RequestUri.ToString();
        // If the request URI contains "blocked", stop processing
        if (uriText.Contains("blocked"))
            return;

        // Otherwise, forward the request to the next handler
        Next(context);
    }
}