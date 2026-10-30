// Load an HTML page, disable JavaScript execution, and ensure dynamic content does not appear.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file containing JavaScript that adds dynamic content
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><script>document.addEventListener('DOMContentLoaded',function(){var p=document.createElement('p');p.textContent='Dynamic content';document.body.appendChild(p);});</script></head><body><p>Static content</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Configure Aspose.HTML to disable script execution
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security = Aspose.Html.Sandbox.None; // disable all sandbox features, including scripts

            // Load the HTML document with the security configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                string result = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}