// Develop a unit test verifying NetworkDisabledMessageHandler blocks disallowed protocols during HTML loading.

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
            // Prepare a temporary HTML file for allowed scenario
            string tempDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "AsposeHtmlTest");
            System.IO.Directory.CreateDirectory(tempDir);
            string htmlFilePath = System.IO.Path.Combine(tempDir, "sample.html");
            System.IO.File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><body><p>Local file test.</p></body></html>");

            // Configure Aspose.HTML with the custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Test allowed file loading
            using (Aspose.Html.HTMLDocument allowedDoc = new Aspose.Html.HTMLDocument(htmlFilePath, configuration))
            {
                System.Console.WriteLine("Allowed file loaded successfully.");
            }

            // Test disallowed protocol loading
            bool blocked = false;
            try
            {
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com");
                using (Aspose.Html.HTMLDocument disallowedDoc = new Aspose.Html.HTMLDocument(request, configuration))
                {
                    // If we reach here, the handler did not block the request
                }
            }
            catch (System.InvalidOperationException ex)
            {
                System.Console.WriteLine("Disallowed protocol blocked as expected: " + ex.Message);
                blocked = true;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Unexpected exception during disallowed protocol test: " + ex);
                blocked = false;
            }

            if (!blocked)
            {
                System.Console.WriteLine("Test failed: Disallowed protocol was not blocked.");
            }
            else
            {
                System.Console.WriteLine("Test passed: Disallowed protocol was correctly blocked.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex);
        }
    }
}