// Detect and remove stray backticks that do not form valid code spans to clean markup.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace CleanMarkup
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                var document = new Aspose.Html.HTMLDocument(inputPath);

                var elements = document.QuerySelectorAll("body *:not(code):not(pre)");
                foreach (Aspose.Html.HTMLElement element in elements)
                {
                    element.InnerHTML = element.InnerHTML.Replace("`", string.Empty);
                }

                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}