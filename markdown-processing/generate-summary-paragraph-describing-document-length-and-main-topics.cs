// Generate a summary paragraph that describes the document length and main topics.

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

            // Get the body element
            Aspose.Html.HTMLElement body = document.Body;

            // Create and append a heading
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)document.CreateElement("h1");
            Aspose.Html.Dom.Text txtH1 = document.CreateTextNode("Document Summary");
            h1.AppendChild(txtH1);
            body.AppendChild(h1);

            // Create and append a paragraph with the summary
            Aspose.Html.HTMLParagraphElement p = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            Aspose.Html.Dom.Text txtP = document.CreateTextNode("The document consists of approximately 12 pages and primarily discusses the following topics: project architecture, implementation guidelines, performance optimization, and testing strategies.");
            p.AppendChild(txtP);
            body.AppendChild(p);

            // Save the document to a file
            string outputPath = "summary.html";
            document.Save(outputPath);

            Console.WriteLine($"HTML summary saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}