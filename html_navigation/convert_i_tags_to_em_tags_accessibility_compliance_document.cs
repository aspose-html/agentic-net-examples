// Convert all <i> tags to <em> tags for better accessibility compliance throughout the document.

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

            var iElements = document.GetElementsByTagName("i");
            for (int idx = iElements.Length - 1; idx >= 0; idx--)
            {
                var oldElement = (Aspose.Html.Dom.Element)iElements[idx];
                var newElement = document.CreateElement("em");
                newElement.InnerHTML = oldElement.InnerHTML;
                var parent = oldElement.ParentNode;
                parent.ReplaceChild(newElement, oldElement);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}