// Validate that the document does not contain any raw HTML tags to ensure strict Markdown compliance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<p>Hello <strong>World</strong></p>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("*");
            bool hasTags = elements.Length > 0;
            if (hasTags)
            {
                Console.WriteLine("Document contains raw HTML tags.");
                for (int i = 0; i < elements.Length; i++)
                {
                    Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                    Console.WriteLine($"Tag: {element.TagName}");
                }
            }
            else
            {
                Console.WriteLine("Document does not contain raw HTML tags.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}