// Instantiate HTMLDocument with a URL, append a script element, and prevent execution using sandboxing.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML page to load
            string url = "https://example.com";

            // Configure sandbox to disable script execution
            Configuration configuration = new Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the document with the sandbox configuration
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                // Create a new <script> element
                var script = document.CreateElement("script");
                script.TextContent = "console.log('Hello from appended script');";

                // Append the script element to the document body
                document.Body.AppendChild(script);

                // Output the resulting HTML markup
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}