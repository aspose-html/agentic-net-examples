// Set sandbox flags to disable both scripts and network, load a page, and verify all external calls blocked.

using System;
using System.IO;

public sealed class Program
{
    public static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<html><body><div id=\"myDiv\" style=\"color:red;\">Hello World</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load document from file with sandbox configuration
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine($"Style attribute of #myDiv: {styleAttr}");
            }

            // Load document from HTML string
            var configForString = new Aspose.Html.Configuration();
            configForString.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configForString))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine($"Text content from string document: {text}");
            }

            // Load document again from file and print text content
            var config2 = new Aspose.Html.Configuration();
            config2.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, config2))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine($"Text content from file document: {text}");
            }

            // Load document and print outer HTML
            var config3 = new Aspose.Html.Configuration();
            config3.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, config3))
            {
                string outerHtml = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine($"Outer HTML of document root: {outerHtml}");
            }

            // Register custom network message handler
            var configWithHandler = new Aspose.Html.Configuration();
            configWithHandler.Security |= Aspose.Html.Sandbox.Scripts;

            Aspose.Html.Services.INetworkService networkService = configWithHandler.GetService<Aspose.Html.Services.INetworkService>();
            if (networkService != null)
            {
                networkService.MessageHandlers.Add(new MyMessageHandler());
            }

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configWithHandler))
            {
                // No additional actions; handler will log network activity if any.
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom message handler for network operations
public sealed class MyMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        DateTime startTime = DateTime.UtcNow;
        Next(context);
        DateTime endTime = DateTime.UtcNow;
        TimeSpan elapsed = endTime - startTime;

        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}