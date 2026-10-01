// Replace all <b> tags with <strong> tags to improve semantic markup throughout the document.

using System;
using System.IO;
using System.Linq;

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
                string sampleHtml = "<html><body><p>This is a <b>bold</b> text.</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            var document = new Aspose.Html.HTMLDocument(inputPath);

            var boldElements = document.GetElementsByTagName("b").ToList();

            foreach (var oldElem in boldElements)
            {
                var parent = oldElem.ParentNode;
                var strongElem = (Aspose.Html.HTMLElement)document.CreateElement("strong");
                var oldHtmlElem = oldElem as Aspose.Html.HTMLElement;
                if (oldHtmlElem != null)
                {
                    strongElem.InnerHTML = oldHtmlElem.InnerHTML;
                }
                parent.ReplaceChild(strongElem, oldElem);
            }

            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}