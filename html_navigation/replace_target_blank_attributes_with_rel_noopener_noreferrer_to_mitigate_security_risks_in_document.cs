// Replace target="_blank" attributes with rel="noopener noreferrer" to mitigate security risks in the document.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);

            var nodes = document.QuerySelectorAll("[target='_blank']");
            foreach (HTMLElement element in nodes)
            {
                element.RemoveAttribute("target");
                element.SetAttribute("rel", "noopener noreferrer");
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}