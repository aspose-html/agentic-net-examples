// Ensure the CredentialHandler is inserted at index zero of MessageHandlers before creating any HTMLDocument.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly System.Net.NetworkCredential _credential = new System.Net.NetworkCredential("user", "pass");
    public override void Invoke(INetworkOperationContext context)
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
            Configuration config = new Configuration();
            INetworkService network = config.GetService<INetworkService>();
            network.MessageHandlers.Insert(0, new CredentialHandler());

            using (HTMLDocument document = new HTMLDocument("https://example.com/protected", config))
            {
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}