// Load an HTML page, disable image loading via sandbox, and confirm no images appear in output.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            // HTML content to write
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head>
    <title>Sample</title>
    <style>
        #myDiv { color: red; }
    </style>
</head>
<body>
    <div id='myDiv' style='font-weight:bold;'>Hello World</div>
    <img src='https://example.com/image.png' alt='Sample Image' />
</body>
</html>";

            // Write HTML content to file
            File.WriteAllText(htmlPath, htmlContent);

            // -----------------------------------------------------------------
            // Part 1: Load document with Images sandbox, remove images, convert to PDF
            // -----------------------------------------------------------------
            var configImages = new Aspose.Html.Configuration();
            configImages.Security |= Aspose.Html.Sandbox.Images;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configImages))
            {
                // Remove all <img> elements
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                foreach (Aspose.Html.Dom.Element img in images)
                {
                    img.ParentNode.RemoveChild(img);
                }

                // Convert to PDF
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, pdfPath);
            }

            // -----------------------------------------------------------------
            // Part 2: Load document with Scripts sandbox, read style attribute of element with id "myDiv"
            // -----------------------------------------------------------------
            var configScripts = new Aspose.Html.Configuration();
            configScripts.Security |= Aspose.Html.Sandbox.Scripts;

            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configScripts))
            {
                var element = document.GetElementById("myDiv");
                string styleAttr = element != null ? element.GetAttribute("style") : null;
                Console.WriteLine("Style attribute of #myDiv: " + (styleAttr ?? "null"));
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}