// Configure sandbox to limit JavaScript memory usage, load a script‑intensive page, and monitor resource consumption.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Configure sandbox to allow scripts only
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Create a sample HTML file with intensive JavaScript
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><script>var sum=0; for(var i=0;i<1000000;i++){sum+=i;}</script></head><body><h1>Script‑Intensive Page</h1></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document with the sandbox configuration
            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
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