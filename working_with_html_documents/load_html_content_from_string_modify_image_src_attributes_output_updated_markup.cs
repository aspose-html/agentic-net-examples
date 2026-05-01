// Load HTML content from a string, modify image src attributes, and output the updated markup.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><img src='old1.png'/><p>Sample text</p><img src='old2.jpg'/></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            var images = document.GetElementsByTagName("img");
            int counter = 1;
            foreach (HTMLElement img in images)
            {
                img.SetAttribute("src", $"new{counter}.png");
                counter++;
            }

            Console.WriteLine(document.DocumentElement.OuterHTML);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}