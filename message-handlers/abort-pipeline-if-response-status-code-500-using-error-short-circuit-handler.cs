// Abort pipeline if response status code is 500 using an error‑short‑circuit handler.

using System;

class ErrorShortCircuitHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
        {
            return;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ErrorShortCircuitHandler());

            using (var document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
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