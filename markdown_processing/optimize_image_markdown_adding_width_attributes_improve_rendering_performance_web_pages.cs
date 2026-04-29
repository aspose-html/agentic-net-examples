// Optimize image markdown by adding width attributes to improve rendering performance on web pages.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source markdown file
            string markdownPath = "input.md";
            // Path where the resulting HTML will be saved
            string outputHtmlPath = "output.html";

            // Convert the markdown file to an HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(markdownPath);

            // Find all <img> elements and add a width attribute
            var images = document.QuerySelectorAll("img");
            foreach (var node in images)
            {
                if (node is Element imgElement)
                {
                    imgElement.SetAttribute("width", "600"); // Set desired width
                }
            }

            // Save the modified HTML document to a file
            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}