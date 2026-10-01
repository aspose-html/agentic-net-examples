// Load an HTML file, normalize whitespace inside text nodes, and write the cleaned document.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>   This   is   a   test. </p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            NormalizeWhitespace(document.DocumentElement);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void NormalizeWhitespace(Aspose.Html.Dom.Node node)
    {
        Aspose.Html.Dom.Node child = node.FirstChild;
        while (child != null)
        {
            Aspose.Html.Dom.Node next = child.NextSibling;

            if (child.NodeName == "#text")
            {
                string text = child.NodeValue;
                if (text != null)
                {
                    string normalized = Regex.Replace(text, @"\s+", " ");
                    child.NodeValue = normalized;
                }
            }
            else
            {
                NormalizeWhitespace(child);
            }

            child = next;
        }
    }
}