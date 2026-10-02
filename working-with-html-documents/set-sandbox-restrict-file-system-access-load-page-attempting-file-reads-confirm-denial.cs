// Set sandbox to restrict file system access, load a page attempting file reads, and confirm denial.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class FileAccessDenyHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("File system access is denied by sandbox.");
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
            // Create a temporary HTML file that attempts to load a local file resource
            string htmlPath = Path.Combine(Path.GetTempPath(), "sandbox_test.html");
            string htmlContent = "<html><body><img src=\"file:///C:/Windows/System32/drivers/etc/hosts\" /></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to allow only scripts (no file system access)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Add a custom network handler that denies file URIs
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new FileAccessDenyHandler());

            // Load the HTML document with the restricted configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Attempt to access the image element (this will trigger the network request)
                var img = document.GetElementsByTagName("img")[0];
                string src = img != null ? img.GetAttribute("src") : null;
                Console.WriteLine("Image src attribute: " + src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}