// Load an HTML page, enable sandbox scripts, execute a simple script, and capture console output.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Configure sandbox to allow script execution
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // HTML content with a simple script that modifies the body
            string html = "<!DOCTYPE html><html><head><script>document.body.innerHTML = '<p>Script executed</p>';</script></head><body></body></html>";

            // Load the document with the sandbox configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "", config))
            {
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}