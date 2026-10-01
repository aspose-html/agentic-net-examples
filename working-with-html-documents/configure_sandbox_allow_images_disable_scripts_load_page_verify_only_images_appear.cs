// Configure sandbox to allow images, disable scripts, load a page, and verify only images appear.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string pdfPath = Path.Combine(Path.GetTempPath(), "sample.pdf");
            string tempFile = Path.Combine(Path.GetTempPath(), "temp.html");

            // HTML content with an element that has an id and a style attribute
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><div id=\"myDiv\" style=\"color:red;\">Hello World</div></body></html>";

            // Write HTML content to file
            File.WriteAllText(htmlPath, htmlContent);

            // Configure Aspose.Html with allowed sandbox flags
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Images;
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Load the HTML document using the configuration
            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Convert the HTML document to PDF
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);

                // Retrieve an element by its id and print its style attribute
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine($"Style attribute of #myDiv: {styleAttr}");
            }

            // Additional example: create another HTML file and output its outer HTML
            string anotherHtml = "<!DOCTYPE html><html><body><p>Sample paragraph</p></body></html>";
            File.WriteAllText(tempFile, anotherHtml);

            var config2 = new Aspose.Html.Configuration();
            config2.Security |= Aspose.Html.Sandbox.Scripts;

            using (var doc2 = new Aspose.Html.HTMLDocument(tempFile, config2))
            {
                string outerHtml = doc2.DocumentElement != null ? doc2.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Outer HTML of loaded document:");
                Console.WriteLine(outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}