// Replace all inline event handler attributes (e.g., onclick) with external JavaScript listeners.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace ReplaceInlineHandlers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output HTML file paths
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the HTML document from the input file
                HTMLDocument document = new HTMLDocument(inputPath);

                // Select all elements that have an inline onclick attribute
                var elements = document.QuerySelectorAll("[onclick]");

                // Iterate over the selected elements and remove the onclick attribute
                for (int i = 0; i < elements.Length; i++)
                {
                    Element el = (Element)elements[i];
                    string val = el.GetAttribute("onclick");
                    if (!string.IsNullOrEmpty(val))
                    {
                        el.RemoveAttribute("onclick");
                    }
                }

                // Save the cleaned document to the output file
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}