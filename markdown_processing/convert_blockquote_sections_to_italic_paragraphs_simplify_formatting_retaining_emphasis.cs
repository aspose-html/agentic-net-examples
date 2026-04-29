// Convert blockquote sections into italic paragraphs to simplify formatting while retaining emphasis.

using System;
using System.Linq;
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

            HTMLDocument document = new HTMLDocument(inputPath);

            var blockquotes = document.GetElementsByTagName("blockquote").Cast<HTMLElement>().ToList();

            foreach (var blockquote in blockquotes)
            {
                HTMLParagraphElement paragraph = (HTMLParagraphElement)document.CreateElement("p");
                paragraph.InnerHTML = blockquote.InnerHTML;
                paragraph.SetAttribute("style", "font-style:italic;");
                blockquote.ParentNode.ReplaceChild(paragraph, blockquote);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}