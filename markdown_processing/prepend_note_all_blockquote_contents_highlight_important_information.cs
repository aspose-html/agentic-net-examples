// Prepend the word “NOTE:” to all blockquote contents to highlight important information.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all blockquote elements
            var blockquotes = document.GetElementsByTagName("blockquote");

            // Prepend "NOTE:" to each blockquote's content
            foreach (var node in blockquotes)
            {
                var blockquote = (HTMLElement)node;
                string originalContent = blockquote.InnerHTML;
                blockquote.InnerHTML = "NOTE:" + originalContent;
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