// Load an HTML document, normalize whitespace in text nodes, and save the cleaned markup.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>   This   is   a   sample   text.   </p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all elements in the document
            var allElements = document.GetElementsByTagName("*");

            // Iterate over each element and normalize whitespace in text nodes
            foreach (Aspose.Html.Dom.Element element in allElements)
            {
                foreach (Aspose.Html.Dom.Node node in element.ChildNodes)
                {
                    if (node is Aspose.Html.Dom.Text textNode)
                    {
                        string normalized = Regex.Replace(textNode.Data, @"\s+", " ").Trim();
                        textNode.Data = normalized;
                    }
                }
            }

            // Save the cleaned HTML markup
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}