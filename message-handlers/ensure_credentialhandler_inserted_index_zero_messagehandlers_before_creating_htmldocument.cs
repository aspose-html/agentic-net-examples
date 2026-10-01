// Ensure the CredentialHandler is inserted at index zero of MessageHandlers before creating any HTMLDocument.

using System;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential = new System.Net.NetworkCredential("user", "password");

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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new CredentialHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
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