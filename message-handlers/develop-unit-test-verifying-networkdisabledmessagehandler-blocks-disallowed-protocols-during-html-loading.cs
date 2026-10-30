// Develop a unit test verifying NetworkDisabledMessageHandler blocks disallowed protocols during HTML loading.

using System;
using System.IO;
using Aspose.Html.Net;

public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", System.StringComparison.OrdinalIgnoreCase))
            throw new System.InvalidOperationException("Only local file resources are allowed.");
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare a temporary HTML file (allowed resource)
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlTest");
            Directory.CreateDirectory(tempDir);
            string htmlFilePath = Path.Combine(tempDir, "sample.html");
            File.WriteAllText(htmlFilePath, "<html><body><p>Local file test.</p></body></html>");

            // Configure Aspose.Html with the custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Test 1: Load allowed local file (should succeed)
            try
            {
                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(htmlFilePath, configuration))
                {
                    Console.WriteLine("Allowed file load: SUCCESS");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Allowed file load: FAILED - {ex.Message}");
            }

            // Test 2: Load disallowed HTTP URL (should be blocked)
            bool exceptionThrown = false;
            try
            {
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com");
                using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(request, configuration))
                {
                    // If we reach here, the handler failed to block the request
                }
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
                Console.WriteLine("Disallowed protocol load: BLOCKED as expected");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Disallowed protocol load: FAILED with unexpected exception - {ex.Message}");
            }

            if (!exceptionThrown)
            {
                Console.WriteLine("Disallowed protocol load: FAILED - no exception thrown");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}