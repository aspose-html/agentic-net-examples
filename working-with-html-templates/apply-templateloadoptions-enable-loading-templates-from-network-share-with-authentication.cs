// Apply TemplateLoadOptions to enable loading templates from a network share with authentication.

using System;
using System.Net;

class NetworkCredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;
    public NetworkCredentialHandler(ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credentials;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and attach credential handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new NetworkCredentialHandler(new NetworkCredential("username", "password")));

            // Path to the template on a network share (replace with an actual UNC path if available)
            string templatePath = @"\\server\share\template.html";

            // Load the HTML document using the configuration with authentication
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(templatePath, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}