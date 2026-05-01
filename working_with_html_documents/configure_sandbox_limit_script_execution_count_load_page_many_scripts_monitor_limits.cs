// Configure sandbox to limit script execution count, load a page with many scripts, and monitor limits.

using System;
using Aspose.Html;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script sandboxing
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Optional: set JavaScript execution timeout if supported
            var runtime = config.GetService<Aspose.Html.Services.IRuntimeService>();
            if (runtime != null)
            {
                runtime.JavaScriptTimeout = TimeSpan.FromSeconds(5);
            }

            // HTML content with multiple script tags
            string html = @"
                <html>
                    <head>
                        <script>console.log('script 1');</script>
                        <script>console.log('script 2');</script>
                        <script>console.log('script 3');</script>
                    </head>
                    <body>
                        <h1>Sample Page</h1>
                        <p>Testing script execution limits.</p>
                    </body>
                </html>";

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "http://example.com", config))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}