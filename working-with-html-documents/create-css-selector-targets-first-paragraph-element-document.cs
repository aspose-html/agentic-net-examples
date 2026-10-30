// Create a CSS selector that targets the first paragraph element in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>First paragraph</p><p>Second paragraph</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var firstParagraph = document.QuerySelector("p:first-of-type");
            firstParagraph.SetAttribute("style", "color:rgb(50,150,200); background-color:#e1f0fe;");
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}