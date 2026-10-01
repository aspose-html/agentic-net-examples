// Insert a horizontal rule before each code block to visually separate code from surrounding text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><h1>Hello Aspose.HTML</h1></body></html>";

            // Create HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Create a <style> element and add CSS
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "h1 { color: red; }";

            // Append the style to the <head>
            Aspose.Html.Dom.Element head = System.Linq.Enumerable.First(document.GetElementsByTagName("head"));
            head.AppendChild(style);

            // Save the document to a file
            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            System.Console.WriteLine($"HTML document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}