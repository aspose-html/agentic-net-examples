// Generate a summary paragraph that describes the document length and main topics.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";

            var document = new Aspose.Html.HTMLDocument();
            var body = document.Body;

            var h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            var txtH1 = document.CreateTextNode("Document Summary");
            h1.AppendChild(txtH1);

            var paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            var summaryText = "The document is short, covering the main topics of Aspose.HTML usage, including creating elements, adding text, and saving the file.";
            var txtP = document.CreateTextNode(summaryText);
            paragraph.AppendChild(txtP);

            body.AppendChild(h1);
            body.AppendChild(paragraph);

            document.Save(outputPath);
            Console.WriteLine($"HTML document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}