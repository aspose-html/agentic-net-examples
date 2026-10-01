// Develop a unit test verifying NetworkDisabledMessageHandler blocks disallowed protocols during HTML loading.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;

public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("Only local file resources are allowed.");
        }
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Prepare temporary local HTML file
            string tempFolder = Path.Combine(Path.GetTempPath(), "AsposeHtmlTest");
            Directory.CreateDirectory(tempFolder);
            string localHtmlPath = Path.Combine(tempFolder, "test.html");
            File.WriteAllText(localHtmlPath, "<!DOCTYPE html><html><body><p>Local test</p></body></html>");

            // Configure Aspose.HTML with the custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Test loading local file (should succeed)
            using (Aspose.Html.HTMLDocument localDoc = new Aspose.Html.HTMLDocument(localHtmlPath, configuration))
            {
                Console.WriteLine("Local HTML loaded successfully.");
            }

            // Test loading remote URL (should be blocked)
            bool remoteLoadBlocked = false;
            try
            {
                using (Aspose.Html.HTMLDocument remoteDoc = new Aspose.Html.HTMLDocument("http://example.com", configuration))
                {
                    // If no exception, the test fails
                }
            }
            catch (InvalidOperationException ex)
            {
                remoteLoadBlocked = true;
                Console.WriteLine("Remote load blocked as expected: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception during remote load: " + ex);
            }

            if (!remoteLoadBlocked)
            {
                Console.WriteLine("Test failed: remote URL was not blocked.");
            }

            // Cleanup
            try
            {
                if (File.Exists(localHtmlPath))
                {
                    File.Delete(localHtmlPath);
                }
                if (Directory.Exists(tempFolder))
                {
                    Directory.Delete(tempFolder, true);
                }
            }
            catch (Exception cleanupEx)
            {
                Console.WriteLine("Cleanup error: " + cleanupEx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }
}