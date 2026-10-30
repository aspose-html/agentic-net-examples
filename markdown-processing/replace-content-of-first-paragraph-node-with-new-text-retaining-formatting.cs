// Replace the content of the first paragraph node with new text while retaining its formatting.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><p style='color:red;'>Original text</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, "about:blank");

            var paragraphs = document.GetElementsByTagName("p");
            if (paragraphs.Length > 0)
            {
                var paragraph = (Aspose.Html.HTMLParagraphElement)paragraphs[0];

                while (paragraph.HasChildNodes())
                {
                    paragraph.RemoveChild(paragraph.FirstChild);
                }

                var newText = document.CreateTextNode("New content");
                paragraph.AppendChild(newText);
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}