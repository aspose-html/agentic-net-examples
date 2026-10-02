// Insert the custom CredentialHandler at the start of the pipeline using configuration.MessageHandlers.Insert.

using System;

class MyCredentialHandler : Aspose.Html.Net.MessageHandler
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
            network.MessageHandlers.Insert(0, new MyCredentialHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                document.Save("output.html");
            }

            Console.WriteLine("HTML document saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}