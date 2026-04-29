// Demonstrate loading a protected HTML page using NTLM authentication and validate the response content.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class NtlmAuthHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        string authHeader = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("NTLM", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Configure Aspose.HTML and register the NTLM authentication handler
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new NtlmAuthHandler());

            // Prepare the request with NTLM credentials
            RequestMessage request = new RequestMessage("http://example.com/protected");
            request.Credentials = new NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load the protected HTML document
            using HTMLDocument document = new HTMLDocument(request, configuration);

            // Validate the response content
            string content = document.Body.InnerHTML;
            if (!string.IsNullOrEmpty(content))
            {
                Console.WriteLine("Document loaded successfully. Content length: " + content.Length);
            }
            else
            {
                Console.WriteLine("Document loaded but content is empty.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}