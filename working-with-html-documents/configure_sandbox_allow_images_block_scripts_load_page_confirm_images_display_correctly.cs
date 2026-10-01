// Configure sandbox to allow images but block scripts, load a page, and confirm images display correctly.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><div id='myDiv' style='color:red;'>Hello Aspose.HTML</div></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load document with script sandbox enabled and read a style attribute
            var config1 = new Aspose.Html.Configuration();
            config1.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config1))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine($"Style attribute of #myDiv: {styleAttr}");
            }

            // Convert HTML to PDF with image sandbox enabled
            string pdfPath = "output.pdf";
            var config2 = new Aspose.Html.Configuration();
            config2.Security |= Aspose.Html.Sandbox.Images;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config2))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), pdfPath);
                Console.WriteLine($"PDF saved to: {pdfPath}");
            }

            // Load document again and output plain text content
            var config3 = new Aspose.Html.Configuration();
            config3.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config3))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine($"Document text content: {text}");
            }

            // Load document and output outer HTML
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, config3))
            {
                string outerHtml = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine($"Document outer HTML: {outerHtml}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}