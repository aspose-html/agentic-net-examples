// Load an HTML file, replace all <i> tags with <em> tags, and save the updated file.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace ReplaceITags
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                HTMLDocument document = new HTMLDocument(inputPath);

                var iElements = document.GetElementsByTagName("i");
                for (int i = iElements.Length - 1; i >= 0; i--)
                {
                    var iElem = (Aspose.Html.HTMLElement)iElements[i];
                    string inner = iElem.InnerHTML;
                    iElem.OuterHTML = $"<em>{inner}</em>";
                }

                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}