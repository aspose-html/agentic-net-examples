// Generate a word count statistic and embed it as a comment at the top of the document.

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

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            Aspose.Html.Dom.Text txtH1 = doc.CreateTextNode("Sample Document");
            h1.AppendChild(txtH1);

            Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)doc.CreateElement("p");
            Aspose.Html.Dom.Text txtP = doc.CreateTextNode("This is a sample paragraph with some words.");
            p.AppendChild(txtP);

            doc.Body.AppendChild(h1);
            doc.Body.AppendChild(p);

            string allText = doc.Body.TextContent ?? "";
            int wordCount = allText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            Aspose.Html.Dom.Comment comment = doc.CreateComment($" WordCount: {wordCount} ");
            doc.InsertBefore(comment, doc.FirstChild);

            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}