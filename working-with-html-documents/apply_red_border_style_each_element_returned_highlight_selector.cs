// Apply a red border style to each element returned by the highlight selector.

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
            // Prepare sample HTML content
            string htmlContent = @"<html>
<head><title>Sample</title></head>
<body>
<h1>Header</h1>
<p>Paragraph.</p>
</body>
</html>";

            // 1. Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // 2. Modify the first <h1> element: add border style and color
            Aspose.Html.HTMLElement header = (Aspose.Html.HTMLElement)document.GetElementsByTagName("h1").First();
            header.Style.BorderStyle = "solid";
            header.Style.BorderColor = "red";

            // Save intermediate result
            string outputPath1 = Path.Combine(Directory.GetCurrentDirectory(), "output1.html");
            document.Save(outputPath1);

            // 3. Create a <style> element and add CSS rule
            Aspose.Html.Dom.Element styleElement = document.CreateElement("style");
            styleElement.TextContent = "p { color: blue; }";

            // Append the style element to <head>
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head").First();
            head.AppendChild(styleElement);

            // Save intermediate result
            string outputPath2 = Path.Combine(Directory.GetCurrentDirectory(), "output2.html");
            document.Save(outputPath2);

            // 4. Append additional CSS rule to the existing <style> element
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.QuerySelector("style");
            style.TextContent = style.TextContent + "\n" + "h1 { color: green; }";

            // Save intermediate result
            string outputPath3 = Path.Combine(Directory.GetCurrentDirectory(), "output3.html");
            document.Save(outputPath3);

            // 5. Change background color of all elements
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("*");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "yellow";
            }

            // Save final result
            string outputPath4 = Path.Combine(Directory.GetCurrentDirectory(), "output4.html");
            document.Save(outputPath4);

            Console.WriteLine("HTML processing completed successfully.");
            Console.WriteLine($"Files created:\n{outputPath1}\n{outputPath2}\n{outputPath3}\n{outputPath4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}