// Append a disclaimer paragraph at the end of the file to inform readers of usage terms.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            var document = new Aspose.Html.HTMLDocument(inputPath);
            var body = document.Body;
            var paragraph = (Aspose.Html.HTMLParagraphElement)document.CreateElement("p");
            paragraph.SetAttribute("id", "disclaimer");
            var textNode = document.CreateTextNode("Disclaimer: This document is for informational purposes only.");
            paragraph.AppendChild(textNode);
            body.AppendChild(paragraph);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}