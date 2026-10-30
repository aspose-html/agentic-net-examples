// Configure sandbox to allow images, load a page with mixed content, and verify only images load.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title><script>document.body.innerHTML += '<div id=\"scriptDiv\">Script Ran</div>';</script></head><body><img id=\"testImg\" src=\"https://via.placeholder.com/150\" /></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var imgElement = document.GetElementById("testImg");
                var scriptDiv = document.GetElementById("scriptDiv");

                Console.WriteLine("Image element: " + (imgElement != null ? "found" : "not found"));
                Console.WriteLine("Script-generated element: " + (scriptDiv != null ? "found" : "not found"));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}