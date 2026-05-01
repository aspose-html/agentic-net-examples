// Insert an img element as a CSS background-image for a section using internal style, then save.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths to the input and output HTML files
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the existing HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Create a <style> element
            HTMLStyleElement styleElement = (HTMLStyleElement)document.CreateElement("style");

            // Define CSS to set a background image for <section> elements
            string css = "section { background-image: url('background.jpg'); }";

            // Add the CSS text to the style element
            Aspose.Html.Dom.Text textNode = document.CreateTextNode(css);
            styleElement.AppendChild(textNode);

            // Retrieve the <head> element; create it if it does not exist
            HTMLElement head = document.QuerySelector("head") as HTMLElement;
            if (head == null)
            {
                head = (HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Append the style element to the head
            head.AppendChild(styleElement);

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}