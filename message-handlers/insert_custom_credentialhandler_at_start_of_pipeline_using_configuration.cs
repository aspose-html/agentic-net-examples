// Insert the custom CredentialHandler at the start of the pipeline using configuration.MessageHandlers.Insert.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential = new NetworkCredential("username", "password");
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
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new CredentialHandler());

            string url = "https://example.com";
            using (var document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}