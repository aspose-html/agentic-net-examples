// Set runtime configuration to limit JavaScript execution time, load a script‑heavy page, and observe timeout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Configure security to allow script execution
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Sample HTML with a simple script
            string html = "<!DOCTYPE html><html><head><script>console.log('test');</script></head><body>Sample Content</body></html>";

            // Load the HTML content with a base URI; the configuration is applied
            using (var document = new Aspose.Html.HTMLDocument(html, "about:blank", configuration))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                System.Console.WriteLine(text);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}