// Validate that no paragraph exceeds two hundred words to maintain concise content standards.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            var paragraphs = document.GetElementsByTagName("p");
            foreach (var node in paragraphs)
            {
                var para = node as Aspose.Html.Dom.Element;
                if (para == null) continue;
                string text = para.TextContent;
                int wordCount = 0;
                if (!string.IsNullOrWhiteSpace(text))
                {
                    wordCount = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                }
                if (wordCount > 200)
                {
                    Console.WriteLine($"Paragraph exceeds 200 words: {wordCount} words.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}