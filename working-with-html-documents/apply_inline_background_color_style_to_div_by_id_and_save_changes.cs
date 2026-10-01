// Apply an inline background-color style to a div identified by ID and save the changes.

using System;
using System.IO;
using System.Linq;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string inputPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // 1. Load document, remove existing background-color, add new style element, save
            var document1 = new Aspose.Html.HTMLDocument(inputPath);
            var body1 = (Aspose.Html.HTMLElement)document1.GetElementsByTagName("body").First();
            body1.Style.RemoveProperty("background-color");

            var styleElement1 = (Aspose.Html.HTMLElement)document1.CreateElement("style");
            styleElement1.TextContent = "body { background-color: rgb(229, 243, 253) }";

            var head1 = (Aspose.Html.HTMLElement)document1.GetElementsByTagName("head").First();
            head1.AppendChild(styleElement1);

            string outputPath1 = "output1.html";
            document1.Save(outputPath1);

            // 2. Load document, find the style element, append additional CSS, save
            var document2 = new Aspose.Html.HTMLDocument(outputPath1);
            var styleElement2 = (Aspose.Html.HTMLElement)document2.QuerySelector("style");
            if (styleElement2 != null)
            {
                styleElement2.TextContent = styleElement2.TextContent + " p { color: blue; }";
            }
            string outputPath2 = "output2.html";
            document2.Save(outputPath2);

            // 3. Load document, change background color of first paragraph, save
            var document3 = new Aspose.Html.HTMLDocument(outputPath2);
            var paragraph = (Aspose.Html.HTMLElement)document3.GetElementsByTagName("p").First();
            paragraph.Style.BackgroundColor = "lightgreen";
            string outputPath3 = "output3.html";
            document3.Save(outputPath3);

            // 4. Load document, set background image on body, save
            var document4 = new Aspose.Html.HTMLDocument(outputPath3);
            var bodyElement4 = (Aspose.Html.HTMLElement)document4.QuerySelector("body");
            if (bodyElement4 != null)
            {
                bodyElement4.SetAttribute("style", "background-image: url('flower.png');");
            }
            string outputPath4 = "output4.html";
            document4.Save(outputPath4);

            // 5. Load document, set background color for all paragraphs, save
            var document5 = new Aspose.Html.HTMLDocument(outputPath4);
            var elements = document5.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "yellow";
            }
            string outputPath5 = "output5.html";
            document5.Save(outputPath5);

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}