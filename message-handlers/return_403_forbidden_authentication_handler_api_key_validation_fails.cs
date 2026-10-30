// Return 403 Forbidden from authentication handler when API key validation fails.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new AuthHandler());

            string html = "<html><body><h1>Hello World</h1></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(html, configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

class AuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers["X-API-Key"]))
        {
            context.Response.StatusCode = System.Net.HttpStatusCode.Forbidden;
            return;
        }
        Next(context);
    }
}