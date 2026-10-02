// Configure TemplateLoadOptions to ignore script tags during template loading for security purposes.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a temporary HTML file containing a script tag
            string htmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            string htmlContent = "<html><head><script>console.log('test');</script></head><body><p>Hello, world!</p></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Configure Aspose.HTML to ignore scripts (do not enable the Scripts sandbox flag)
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            // No config.Security |= Aspose.Html.Sandbox.Scripts; – scripts will be ignored

            // Load the HTML document with the security configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config))
            {
                string output = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine(output);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}