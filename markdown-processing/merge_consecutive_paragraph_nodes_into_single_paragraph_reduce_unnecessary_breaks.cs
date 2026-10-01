// Merge consecutive paragraph nodes into a single paragraph to reduce unnecessary breaks.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument();

            // Access the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create first paragraph with text "First paragraph."
            Aspose.Html.HTMLParagraphElement p1 = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            Aspose.Html.Dom.Text txt1 = document.CreateTextNode("First paragraph.");
            p1.AppendChild(txt1);
            body.AppendChild(p1);

            // Create second paragraph with text "Second paragraph."
            Aspose.Html.HTMLParagraphElement p2 = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            Aspose.Html.Dom.Text txt2 = document.CreateTextNode("Second paragraph.");
            p2.AppendChild(txt2);
            body.AppendChild(p2);

            // Merge the two paragraphs into a single paragraph
            Aspose.Html.HTMLParagraphElement merged = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            // Combine texts from both paragraphs
            Aspose.Html.Dom.Text mergedText = document.CreateTextNode(txt1.Data + " " + txt2.Data);
            merged.AppendChild(mergedText);
            // Append the merged paragraph to the body
            body.AppendChild(merged);

            // Save the document to a file
            string outputPath = "merged_paragraphs.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}