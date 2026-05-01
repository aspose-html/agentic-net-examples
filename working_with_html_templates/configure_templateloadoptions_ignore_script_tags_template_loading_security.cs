// Configure TemplateLoadOptions to ignore script tags during template loading for security purposes.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script blocking
            Configuration config = new Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // Path to the HTML template
            string templatePath = "template.html";

            // Load the template with the security configuration
            using (HTMLDocument document = new HTMLDocument(templatePath, config))
            {
                // Output the loaded HTML (scripts are ignored)
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}