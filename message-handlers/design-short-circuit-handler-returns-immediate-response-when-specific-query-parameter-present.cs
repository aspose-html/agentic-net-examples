// Design a short‑circuit handler that returns immediate response when specific query parameter is present.

using System;

public class ShortCircuitHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string uriText = context.Request.RequestUri.ToString();
        if (uriText.Contains("skip=true"))
        {
            // Short-circuit: do not continue processing the request
            return;
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
            // Create Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Obtain network service and add the short-circuit handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ShortCircuitHandler());

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load the document using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                Console.WriteLine("HTML document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}