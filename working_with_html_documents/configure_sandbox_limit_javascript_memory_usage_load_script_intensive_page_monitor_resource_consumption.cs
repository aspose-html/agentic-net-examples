// Configure sandbox to limit JavaScript memory usage, load a script‑intensive page, and monitor resource consumption.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script execution (will be limited by timeout)
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Set JavaScript execution timeout if the runtime service is available
            var runtime = config.GetService<Aspose.Html.Services.IRuntimeService>();
            if (runtime != null)
            {
                runtime.JavaScriptTimeout = TimeSpan.FromSeconds(5);
            }

            // URL of a script‑intensive page
            string url = "https://example.com/script-intensive.html";

            // Load the document with the configured sandbox
            using (var document = new Aspose.Html.HTMLDocument(url, config))
            {
                // Output text content to monitor resource consumption
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