// Demonstrate loading a protected HTML page using Basic authentication and validate the response content.

using System;

class BasicAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public BasicAuthHandler()
    {
        // Replace with actual username, password, and domain (empty string for no domain)
        _credential = new System.Net.NetworkCredential("username", "password", "");
    }

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
            // Create configuration and attach the authentication handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new BasicAuthHandler());

            // Load the protected HTML page using Basic authentication
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("http://example.com/protected", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                // Simple validation of the response content
                if (!string.IsNullOrEmpty(html) && html.Contains("Welcome"))
                {
                    Console.WriteLine("Content validated successfully.");
                }
                else
                {
                    Console.WriteLine("Content validation failed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}