// Insert the custom CredentialHandler at the start of the pipeline using configuration.MessageHandlers.Insert.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CustomCredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential = new NetworkCredential("username", "password");

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and insert the custom handler at the start of the pipeline
            INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new CustomCredentialHandler());

            // Load an HTML document using the configuration with the custom handler
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Save the document to a file
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}