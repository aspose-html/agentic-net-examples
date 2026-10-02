// Load an HTML file, normalize whitespace inside text nodes, and write the cleaned document.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>   This   is   a   test.\nNew line   </p></body></html>");
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Normalize whitespace in text nodes
            NormalizeWhitespace(document.DocumentElement);

            // Save the cleaned document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void NormalizeWhitespace(Aspose.Html.Dom.Node node)
    {
        var child = node.FirstChild;
        while (child != null)
        {
            var next = child.NextSibling;

            if (child.NodeName == "#text")
            {
                string text = child.NodeValue;
                string normalized = Regex.Replace(text, @"\s+", " ").Trim();
                child.NodeValue = normalized;
            }
            else
            {
                NormalizeWhitespace(child);
            }

            child = next;
        }
    }
}