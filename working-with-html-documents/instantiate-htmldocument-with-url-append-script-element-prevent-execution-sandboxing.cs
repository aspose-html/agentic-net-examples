// Instantiate HTMLDocument with a URL, append a script element, and prevent execution using sandboxing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Configure sandbox to prevent script execution
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load document from a URL with the sandbox configuration
            string url = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Create a script element
                Aspose.Html.Dom.Element script = document.CreateElement("script");
                script.TextContent = "console.log('Hello from sandboxed script');";

                // Append the script to the document body
                Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.Body;
                body.AppendChild(script);

                // Output the resulting HTML
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