// Confirm that inserting CredentialHandler does not affect loading of non-protected HTML pages.

using System;
using System.IO;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;
    public CredentialHandler(ICredentials credentials)
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
            // Prepare a simple non-protected HTML file
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello, World!</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Create configuration and add credential handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler(new NetworkCredential("user", "password")));

            // Load the non-protected HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Loaded HTML length: " + html.Length);
            }

            // Clean up temporary file
            if (File.Exists(htmlPath))
            {
                File.Delete(htmlPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}