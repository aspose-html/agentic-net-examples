// Abort pipeline if response status code is 500 using an error‑short‑circuit handler.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

public class ErrorShortCircuitHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode == HttpStatusCode.InternalServerError)
        {
            // Abort further processing
            return;
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add the error‑short‑circuit handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ErrorShortCircuitHandler());

            // Load a document (example URL that returns 500)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://httpstat.us/500", configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}