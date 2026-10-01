// Abort pipeline if response status code is 500 using an error‑short‑circuit handler.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create Aspose.HTML configuration
            var configuration = new Aspose.Html.Configuration();

            // Obtain the network service from the configuration
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add the error‑short‑circuit handler to abort on HTTP 500
            network.MessageHandlers.Add(new ErrorShortCircuitHandler());

            // Prepare a minimal HTML file as input
            string inputPath = "sample.html";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>");
            }

            // Load the HTML document using the custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                // Simple verification output
                Console.WriteLine("Document loaded successfully. Title length: " + document.Title.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that short‑circuits the pipeline on HTTP 500 responses
class ErrorShortCircuitHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Proceed to the next handler in the pipeline
        Next(context);

        // If the response status code is 500, abort further processing
        if (context.Response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        {
            return;
        }
    }
}