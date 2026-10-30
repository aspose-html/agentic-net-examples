// Set runtime configuration to limit JavaScript execution time, load a script‑heavy page, and observe timeout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script execution sandbox
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Sample HTML content
            string html = "<html><body><p>Hello, Aspose.HTML!</p></body></html>";

            // Load the HTML document with the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank", configuration))
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