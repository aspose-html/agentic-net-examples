// Remove existing style elements from the head before inserting new CSS rules for text color.

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
            // Paths to the input and output HTML files
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get the <head> element
            Element head = (Element)document.GetElementsByTagName("head").First();

            // Remove all existing <style> elements from the head
            var existingStyles = head.GetElementsByTagName("style");
            foreach (Element style in existingStyles)
            {
                head.RemoveChild(style);
            }

            // Create a new <style> element with a CSS rule for text color
            Element newStyle = document.CreateElement("style");
            newStyle.TextContent = "body { color: rgb(255,0,0) }";

            // Append the new style element to the head
            head.AppendChild(newStyle);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}