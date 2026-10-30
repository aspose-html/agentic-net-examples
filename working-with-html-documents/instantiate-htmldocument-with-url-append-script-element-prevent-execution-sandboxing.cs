// Instantiate HTMLDocument with a URL, append a script element, and prevent execution using sandboxing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Configure sandbox to disable script execution
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load HTML document from a URL with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Create a script element
                Aspose.Html.HTMLElement script = (Aspose.Html.HTMLElement)document.CreateElement("script");
                script.TextContent = "console.log('This script should not run');";

                // Append the script element to the document body
                document.Body.AppendChild(script);

                // Output the resulting HTML
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine(html);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}