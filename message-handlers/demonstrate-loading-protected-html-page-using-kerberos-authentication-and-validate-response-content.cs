// Demonstrate loading a protected HTML page using Kerberos authentication and validate the response content.

using System;

class KerberosHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public KerberosHandler()
    {
        _credential = new System.Net.NetworkCredential("username", "password", "DOMAIN");
    }

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
            network.MessageHandlers.Add(new KerberosHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("http://example.com/protected", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                if (!string.IsNullOrEmpty(html) && html.Contains("ExpectedContent"))
                {
                    Console.WriteLine("Content validated successfully.");
                }
                else
                {
                    Console.WriteLine("Content validation failed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}