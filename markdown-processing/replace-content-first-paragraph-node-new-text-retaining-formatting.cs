// Replace the content of the first paragraph node with new text while retaining its formatting.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            Aspose.Html.HTMLElement body = document.Body;

            Aspose.Html.HTMLParagraphElement paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            paragraph.SetAttribute("style", "color:red; font-weight:bold;");

            Aspose.Html.Dom.Text oldText = document.CreateTextNode("Original paragraph text.");
            paragraph.AppendChild(oldText);
            body.AppendChild(paragraph);

            // Replace content of the first paragraph while retaining formatting
            while (paragraph.HasChildNodes())
            {
                paragraph.RemoveChild(paragraph.FirstChild);
            }

            Aspose.Html.Dom.Text newText = document.CreateTextNode("New replaced text.");
            paragraph.AppendChild(newText);

            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}