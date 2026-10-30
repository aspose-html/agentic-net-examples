// Load an HTML page, enable sandbox scripts, execute a simple script, and capture console output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><script>document.body.innerHTML = 'Script executed';</script></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                var bodyCollection = document.GetElementsByTagName("body");
                Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)bodyCollection[0];
                string output = body != null ? body.InnerHTML : string.Empty;
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}