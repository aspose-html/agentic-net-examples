// Wrap each paragraph element inside a div with a specific CSS class for layout control.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a sample HTML file with paragraphs
            string htmlContent = "<html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Wrap each <p> element inside a <div class=\"layout-paragraph\">
            var paragraphs = document.GetElementsByTagName("p");
            foreach (Aspose.Html.HTMLElement paragraph in paragraphs)
            {
                // Create wrapper div
                var wrapper = (Aspose.Html.HTMLElement)document.CreateElement("div");
                wrapper.SetAttribute("class", "layout-paragraph");

                // Replace paragraph with wrapper and move paragraph inside wrapper
                var parent = paragraph.ParentNode;
                parent.ReplaceChild(wrapper, paragraph);
                wrapper.AppendChild(paragraph);
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}