// Demonstrate loading a protected HTML page using NTLM authentication and validate the response content.

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add NTLM authentication handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new NtlmAuthHandler());

            // Prepare request with NTLM credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load the protected HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Validate response content (e.g., check title)
                string title = document.Title;
                System.Console.WriteLine("Page title: " + title);
                if (string.IsNullOrEmpty(title))
                {
                    System.Console.WriteLine("Failed to load protected content or title is empty.");
                }
                else
                {
                    System.Console.WriteLine("Protected page loaded successfully.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class NtlmAuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string authHeader = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("NTLM", System.StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}