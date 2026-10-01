// Load an HTML document from a URL with authentication headers, and ensure the request succeeds with proper credentials.

using System;
using System.Net;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add custom message handlers
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler());
            network.MessageHandlers.Add(new AuthValidatorHandler());

            // Prepare request with credentials
            var request = new Aspose.Html.Net.RequestMessage("https://httpbin.org/basic-auth/user/passwd");
            request.Credentials = new NetworkCredential("user", "passwd");
            request.PreAuthenticate = true;

            // Load document using the request
            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html) && html.Contains("authenticated"))
                    Console.WriteLine("Authentication succeeded.");
                else
                    Console.WriteLine("Authentication failed or content not as expected.");
            }

            // Navigate to a page and retrieve its text content
            string url = "https://httpbin.org/html";
            using (var resetEvent = new AutoResetEvent(false))
            using (var navDoc = new Aspose.Html.HTMLDocument())
            {
                string htmlResult = string.Empty;
                navDoc.OnReadyStateChange += (sender, e) =>
                {
                    if (navDoc.ReadyState == "complete")
                    {
                        htmlResult = navDoc.DocumentElement != null ? navDoc.DocumentElement.TextContent : string.Empty;
                        resetEvent.Set();
                    }
                };
                navDoc.Navigate(url);
                // Wait up to 5 seconds for navigation to complete
                resetEvent.WaitOne(5000);
                Console.WriteLine("Navigated page text content:");
                Console.WriteLine(htmlResult);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Message handler that injects credentials into each request
class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential;

    public CredentialHandler()
    {
        _credential = new NetworkCredential("user", "passwd", "");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

// Message handler that validates the presence of the Authorization header
class AuthValidatorHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        string authValue = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authValue))
            Console.WriteLine("Authorization header present: " + authValue);
        else
            Console.WriteLine("Authorization header missing");
    }
}