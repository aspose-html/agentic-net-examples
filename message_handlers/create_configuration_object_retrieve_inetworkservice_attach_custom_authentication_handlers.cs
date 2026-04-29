// Create a Configuration object and retrieve INetworkService to attach custom authentication handlers.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly ICredentials _credentials;
    public CredentialHandler(ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(INetworkOperationContext context)
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
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler(new NetworkCredential("user", "password")));

            RequestMessage request = new RequestMessage("https://example.com");
            using HTMLDocument document = new HTMLDocument(request, configuration);
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}