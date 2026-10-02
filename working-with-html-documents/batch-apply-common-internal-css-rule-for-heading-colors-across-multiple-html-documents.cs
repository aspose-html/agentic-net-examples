// Batch apply a common internal CSS rule for heading colors across multiple HTML documents.

using System;
using System.IO;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare sample input HTML files
            string inputPath1 = "input1.html";
            string inputPath2 = "input2.html";

            string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Heading 1</h1><p>Paragraph.</p></body></html>";

            File.WriteAllText(inputPath1, sampleHtml);
            File.WriteAllText(inputPath2, sampleHtml);

            // Process first document
            Aspose.Html.HTMLDocument doc1 = new Aspose.Html.HTMLDocument(inputPath1);
            Aspose.Html.Dom.Element style1 = doc1.CreateElement("style");
            style1.TextContent = "h1, h2, h3, h4, h5, h6 { color: blue; }";
            Aspose.Html.Dom.Element head1 = doc1.GetElementsByTagName("head").First();
            head1.AppendChild(style1);
            string outputPath1 = "output1.html";
            doc1.Save(outputPath1);

            // Process second document
            Aspose.Html.HTMLDocument doc2 = new Aspose.Html.HTMLDocument(inputPath2);
            Aspose.Html.Dom.Element style2 = doc2.CreateElement("style");
            style2.TextContent = "h1, h2, h3, h4, h5, h6 { color: blue; }";
            Aspose.Html.Dom.Element head2 = doc2.GetElementsByTagName("head").First();
            head2.AppendChild(style2);
            string outputPath2 = "output2.html";
            doc2.Save(outputPath2);

            Console.WriteLine("CSS rule applied and documents saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}