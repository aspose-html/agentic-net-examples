// Use QuerySelector to retrieve the first matching paragraph element in the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file as input
            string inputPath = "sample.html";
            string htmlContent = "<html><body><p>Hello World</p><div>Test</div></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            var document = new Aspose.Html.HTMLDocument(inputPath);

            // Modify the first <p> element's style attribute
            var pElement = document.QuerySelector("p");
            if (pElement != null)
            {
                pElement.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            // Load the saved document with a base URL (directory of the file)
            var document2 = new Aspose.Html.HTMLDocument(outputPath, Path.GetDirectoryName(outputPath));

            // Traverse child nodes of the body
            var node = document2.Body.FirstChild;
            while (node != null)
            {
                node = node.NextSibling;
            }

            // Get the outer HTML of the document
            string outerHtml = document2.DocumentElement.OuterHTML;
            Console.WriteLine("Outer HTML of the document:");
            Console.WriteLine(outerHtml);
            Console.WriteLine();

            // Query all <p> elements and print their inner HTML
            var nodeList = document2.QuerySelectorAll("p");
            for (int i = 0; i < nodeList.Length; i++)
            {
                var element = nodeList[i] as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    Console.WriteLine($"Paragraph {i + 1} inner HTML: {element.InnerHTML}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}