// Replace inline code spans with emphasized text to demonstrate alternative formatting options.

using System;
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

            HTMLDocument document = new HTMLDocument(inputPath);

            var codeElements = document.GetElementsByTagName("code");
            for (int i = codeElements.Length - 1; i >= 0; i--)
            {
                var code = (Element)codeElements[i];
                var em = document.CreateElement("em");
                em.TextContent = code.TextContent;
                var parent = code.ParentNode;
                parent.ReplaceChild(em, code);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}