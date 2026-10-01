// Add a language attribute to the html tag based on detected content language.

using System;

namespace AsposeHtmlLanguageExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body>Hello world</body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");

                string language = "en";
                if (htmlContent.Contains("Bonjour"))
                {
                    language = "fr";
                }
                else if (htmlContent.Contains("Hola"))
                {
                    language = "es";
                }

                Aspose.Html.Dom.Element htmlElement = document.DocumentElement;
                htmlElement.SetAttribute("lang", language);

                string outputPath = "output.html";
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}