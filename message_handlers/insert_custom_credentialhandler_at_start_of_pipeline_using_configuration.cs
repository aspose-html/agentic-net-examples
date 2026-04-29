// Insert the custom CredentialHandler at the start of the pipeline using configuration.MessageHandlers.Insert.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using System.Net;

class CredentialHandler : MessageHandler
{
    private readonly NetworkCredential credential = new NetworkCredential("username", "password");
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Credentials = credential;
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
            network.MessageHandlers.Insert(0, new CredentialHandler());
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}