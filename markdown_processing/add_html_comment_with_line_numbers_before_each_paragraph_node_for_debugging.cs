// Add an HTML comment containing line numbers before each paragraph node for debugging purposes.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();
            HTMLElement body = document.Body;

            int lineNumber = 1;
            for (int i = 0; i < 3; i++)
            {
                // Insert comment with line number before the paragraph
                Comment comment = document.CreateComment($"Line {lineNumber}");
                body.AppendChild(comment);

                // Create paragraph element with text
                Element paragraph = document.CreateElement("p");
                Text textNode = document.CreateTextNode($"Paragraph {lineNumber}");
                paragraph.AppendChild(textNode);
                body.AppendChild(paragraph);

                lineNumber++;
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}