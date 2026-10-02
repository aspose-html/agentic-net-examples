// Load an HTML file, replace all <b> tags with <strong> tags, and save the updated file.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Hello <b>World</b>!</p></body></html>");
            }

            // Load the HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <b> elements
            var bElements = document.GetElementsByTagName("b");

            // Replace each <b> with <strong>
            foreach (Aspose.Html.Dom.Element b in bElements)
            {
                // Create a new <strong> element
                Aspose.Html.Dom.Element strong = document.CreateElement("strong");

                // Move all child nodes from <b> to <strong>
                while (b.FirstChild != null)
                {
                    strong.AppendChild(b.FirstChild);
                }

                // Replace <b> with <strong> in the DOM
                b.ParentNode.ReplaceChild(strong, b);
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}