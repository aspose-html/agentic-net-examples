// Set sandbox to restrict file system access, load a page attempting file reads, and confirm denial.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a temporary HTML file with sample content
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<html><body><div id=\"myDiv\" style=\"color:red;\">Hello</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Configure sandbox to allow scripts (valid flag)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the document with the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine(styleAttr);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}