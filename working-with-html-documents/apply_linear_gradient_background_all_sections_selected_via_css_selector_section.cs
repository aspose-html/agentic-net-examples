// Apply a linear gradient background to all sections selected via CSS selector ".section".

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = @"<!DOCTYPE html>
<html>
<head></head>
<body>
<p>Paragraph 1</p>
<p>Paragraph 2</p>
<div id=""myDiv"">Div content</div>
</body>
</html>";

            // Create HTML document from string literal
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Change background color of all <p> elements
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                element.Style.BackgroundColor = "lightblue";
            }

            // Create a <style> element with CSS and add it to <head>
            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = "body { font-family: Arial; }";
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);

            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }
            head.AppendChild(styleElement);

            // Save the first version
            string outputPath1 = "output1.html";
            document.Save(outputPath1);
            Console.WriteLine($"Saved document to {outputPath1}");

            // Remove background-color from <body>
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body").First();
            body.Style.RemoveProperty("background-color");

            // Add another style rule
            Aspose.Html.HTMLStyleElement styleElement2 = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css2 = "p { color: red; }";
            Aspose.Html.Dom.Text textNode2 = document.CreateTextNode(css2);
            styleElement2.AppendChild(textNode2);
            head.AppendChild(styleElement2);

            // Save the second version
            string outputPath2 = "output2.html";
            document.Save(outputPath2);
            Console.WriteLine($"Saved document to {outputPath2}");

            // Set a custom attribute on the <div id="myDiv">
            Aspose.Html.HTMLElement div = document.QuerySelector("#myDiv") as Aspose.Html.HTMLElement;
            if (div != null)
            {
                div.SetAttribute("data-test", "123");
            }

            // Save the final version
            string outputPath3 = "output3.html";
            document.Save(outputPath3);
            Console.WriteLine($"Saved document to {outputPath3}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}