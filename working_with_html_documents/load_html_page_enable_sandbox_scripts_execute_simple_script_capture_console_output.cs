// Load an HTML page, enable sandbox scripts, execute a simple script, and capture console output.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script>document.body.innerHTML = 'Hello from script';</script></head><body></body></html>";
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "http://example.com", config))
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