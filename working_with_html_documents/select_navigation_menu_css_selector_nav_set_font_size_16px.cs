// Select the navigation menu using CSS selector "#nav" and set its font size to 16px.

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

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                Element nav = document.QuerySelector("#nav");
                if (nav != null)
                {
                    nav.SetAttribute("style", "font-size:16px;");
                }

                document.Save(outputPath);
            }

            Console.WriteLine("Navigation menu font size set and document saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}