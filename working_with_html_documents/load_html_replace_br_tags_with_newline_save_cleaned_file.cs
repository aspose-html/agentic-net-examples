// Load an HTML file, replace all <br> tags with newline characters, and save the cleaned file.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2)
                throw new ArgumentException("Please provide input and output file paths as arguments.");

            string inputPath = args[0];
            string outputPath = args[1];

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Replace all <br> tags with newline characters
            var brElements = document.GetElementsByTagName("br").Cast<HTMLElement>().ToList();
            foreach (var br in brElements)
            {
                Text textNode = document.CreateTextNode("\n");
                Node parent = br.ParentNode;
                parent.ReplaceChild(textNode, br);
            }

            // Save the cleaned HTML document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}