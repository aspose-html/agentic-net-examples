// Validate that CredentialHandler can be reused for multiple sequential HTMLDocument loads with different URLs.

using System;
using System.IO;
using System.Net;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;

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
            // Create sample HTML files
            string filePath1 = Path.Combine(Path.GetTempPath(), "sample1.html");
            File.WriteAllText(filePath1, "<html><body><h1>Sample 1</h1></body></html>");
            string filePath2 = Path.Combine(Path.GetTempPath(), "sample2.html");
            File.WriteAllText(filePath2, "<html><body><h1>Sample 2</h1></body></html>");

            // Create a reusable credential handler
            MyCredentialHandler credentialHandler = new MyCredentialHandler(new NetworkCredential("user", "pass"));

            // First configuration and document load
            Aspose.Html.Configuration configuration1 = new Aspose.Html.Configuration();
            INetworkService network1 = configuration1.GetService<INetworkService>();
            network1.MessageHandlers.Add(credentialHandler);
            using (Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(filePath1, configuration1))
            {
                Console.WriteLine("Document1 loaded: " + document1.Title);
            }

            // Second configuration and document load using the same handler
            Aspose.Html.Configuration configuration2 = new Aspose.Html.Configuration();
            INetworkService network2 = configuration2.GetService<INetworkService>();
            network2.MessageHandlers.Add(credentialHandler);
            using (Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(filePath2, configuration2))
            {
                Console.WriteLine("Document2 loaded: " + document2.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}