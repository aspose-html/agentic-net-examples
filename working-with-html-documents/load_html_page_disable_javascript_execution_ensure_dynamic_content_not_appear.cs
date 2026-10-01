// Load an HTML page, disable JavaScript execution, and ensure dynamic content does not appear.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the page to load
            string url = "https://example.com";

            // Configure security to disable script execution
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Retrieve the static HTML content
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