// Configure TemplateLoadOptions to ignore script tags during template loading for security purposes.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><script>console.log('test');</script></head><body><p>Hello</p></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            // Intentionally do NOT enable script execution for security:
            // config.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(tempFile, config))
            {
                string output = doc.DocumentElement != null ? doc.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}