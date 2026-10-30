// Apply TemplateLoadOptions to enable loading templates from a network share with authentication.

using System;
using System.Net;
using Aspose.Html.Net;

class MyCredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;
    public MyCredentialHandler(ICredentials credentials)
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
            // Create configuration and add credential handler for network access
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new MyCredentialHandler(new NetworkCredential("username", "password")));

            // Path to the template on a network share (UNC path)
            string templatePath = @"\\myserver\share\template.html";

            // Load the template using the configuration with authentication
            using Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(templatePath, configuration);

            // Output some information to verify loading
            Console.WriteLine("Template loaded successfully.");
            Console.WriteLine("Document title: " + document.Title);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}