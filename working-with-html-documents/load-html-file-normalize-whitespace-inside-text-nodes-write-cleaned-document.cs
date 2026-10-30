// Load an HTML file, normalize whitespace inside text nodes, and write the cleaned document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>   This   is   a   test.\nNew line   </p><!-- comment --></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            NormalizeWhitespace(document.DocumentElement);

            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
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
                    string normalized = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ").Trim();
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