// Develop a unit test verifying NetworkDisabledMessageHandler blocks disallowed protocols during HTML loading.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Only local file resources are allowed.");
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            string htmlPath = Path.Combine(tempDir, "test.html");
            File.WriteAllText(htmlPath, "<html><body><img src=\"http://example.com/image.png\" /></body></html>");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // If loading succeeds, the test fails
                Console.WriteLine("Test Failed: Disallowed protocol was not blocked.");
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Test Passed: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Test Failed with unexpected exception: " + ex);
        }
    }
}