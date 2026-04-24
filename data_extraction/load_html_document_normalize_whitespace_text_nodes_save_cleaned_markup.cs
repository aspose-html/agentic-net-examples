// Load an HTML document, normalize whitespace in text nodes, and save the cleaned markup.

using System;
using Aspose.Html;

namespace HtmlNormalizeExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                using (HTMLDocument document = new HTMLDocument(inputPath))
                {
                    document.Normalize();
                    document.Save(outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}