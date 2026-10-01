// Configure TemplateLoadOptions to ignore script tags during template loading for security purposes.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><div id=\"myDiv\" style=\"color:red;\">Hello</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document with sandbox configuration
            var configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine($"Style attribute of #myDiv: {styleAttr}");
            }

            // Convert the HTML document to PDF
            var pdfDoc = new Aspose.Html.HTMLDocument(htmlPath, configuration);
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            string pdfOutputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(pdfDoc, pdfOptions, pdfOutputPath);
            Console.WriteLine($"PDF saved to: {pdfOutputPath}");

            // Create another HTML content and write to a temporary file
            string htmlContent2 = "<html><body><p>Temp content</p></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "temp.html");
            File.WriteAllText(tempFile, htmlContent2);

            var config2 = new Aspose.Html.Configuration();
            config2.Security |= Aspose.Html.Sandbox.Scripts;

            using (var doc2 = new Aspose.Html.HTMLDocument(tempFile, config2))
            {
                string outerHtml = doc2.DocumentElement != null ? doc2.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("OuterHTML of temporary document:");
                Console.WriteLine(outerHtml);
            }

            // Load the same temporary file again using a different syntax and print its outer HTML
            using (Aspose.Html.HTMLDocument doc3 = new Aspose.Html.HTMLDocument(tempFile, config2))
            {
                string outerHtml = doc3.DocumentElement != null ? doc3.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("OuterHTML of document loaded again:");
                Console.WriteLine(outerHtml);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}