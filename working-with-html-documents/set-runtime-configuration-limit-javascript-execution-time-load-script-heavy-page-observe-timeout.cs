// Set runtime configuration to limit JavaScript execution time, load a script‑heavy page, and observe timeout.

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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Set JavaScript execution timeout
            IRuntimeService runtime = configuration.GetService<IRuntimeService>();
            if (runtime != null)
            {
                runtime.JavaScriptTimeout = TimeSpan.FromSeconds(2);
            }

            // Sample HTML with a long‑running script
            string html = "<html><head><script>var start = Date.now(); while (Date.now() - start < 5000) {} </script></head><body><p>Page loaded after script.</p></body></html>";

            // Load the document with the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank", configuration))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine(text);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}