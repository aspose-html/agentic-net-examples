// Insert a subheading under a specified parent heading using the MarkdownSyntaxFactory to create nodes.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new HTML document
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();

            // Get the body element
            Aspose.Html.HTMLElement body = doc.Body;

            // Create a parent heading (h1)
            Aspose.Html.HTMLHeadingElement h1 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h1");
            Aspose.Html.Dom.Text txtH1 = doc.CreateTextNode("Parent Heading");
            h1.AppendChild(txtH1);

            // Create a subheading (h2)
            Aspose.Html.HTMLHeadingElement h2 = (Aspose.Html.HTMLHeadingElement)doc.CreateElement("h2");
            Aspose.Html.Dom.Text txtH2 = doc.CreateTextNode("Subheading under Parent");
            h2.AppendChild(txtH2);

            // Append headings to the body (h2 follows h1)
            body.AppendChild(h1);
            body.AppendChild(h2);

            // Save the document
            string outputPath = "output.html";
            doc.Save(outputPath);

            Console.WriteLine("HTML document created and saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}