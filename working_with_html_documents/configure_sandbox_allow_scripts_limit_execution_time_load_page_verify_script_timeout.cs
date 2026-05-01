// Configure sandbox to allow scripts but limit execution time, load a page, and verify script timeout.

using System;
using Aspose.Html;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script execution
            var config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Optional: set JavaScript execution timeout if the runtime service is available
            var runtime = config.GetService<IRuntimeService>();
            if (runtime != null)
            {
                runtime.JavaScriptTimeout = TimeSpan.FromSeconds(2);
            }

            // HTML with a long‑running script to trigger the timeout
            string html = "<html><body><script>while(true){};</script></body></html>";

            // Load the document with the configured sandbox
            using (var document = new Aspose.Html.HTMLDocument(html, "http://example.com", config))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            // Output any errors (e.g., script timeout)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}