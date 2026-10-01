// Load an HTML page, extract its title element text, and output the title to console.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input HTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            if (!File.Exists(inputPath))
            {
                string sampleContent = @"<!DOCTYPE html>
<html>
<head>
    <title>Original Title</title>
</head>
<body>
    <p>First paragraph.</p>
    <p>Second paragraph.</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            // Load the HTML document from the file
            string url = new Uri(inputPath).AbsoluteUri;
            var document = new Aspose.Html.HTMLDocument(url);

            // Change the title
            document.Title = "Updated Title";

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"Document saved to: {outputPath}");

            // Query all paragraph elements and print their inner HTML
            var elements = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                Console.WriteLine($"Paragraph inner HTML: {element.InnerHTML}");
            }

            // Access DOM elements and display tag names and text content
            Aspose.Html.Dom.Element htmlElement = document.DocumentElement;
            Aspose.Html.Dom.Element bodyElement = htmlElement.LastElementChild;
            Aspose.Html.Dom.Element firstChild = bodyElement.FirstElementChild;

            string tagHtml = htmlElement.TagName;
            string tagBody = bodyElement.TagName;
            string tagFirst = firstChild.TagName;
            string textFirst = firstChild.TextContent;

            Console.WriteLine($"Tag names -> html: {tagHtml}, body: {tagBody}, first child: {tagFirst}");
            Console.WriteLine($"First child text content: {textFirst}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}