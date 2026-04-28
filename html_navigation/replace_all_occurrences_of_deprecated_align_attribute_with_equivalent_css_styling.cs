// Replace all occurrences of a deprecated attribute (e.g., align) with equivalent CSS styling.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

namespace ReplaceDeprecatedAttribute
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

                NodeList elements = document.QuerySelectorAll("[align]");

                foreach (HTMLElement element in elements)
                {
                    string alignValue = element.GetAttribute("align");
                    if (!string.IsNullOrEmpty(alignValue))
                    {
                        string existingStyle = element.GetAttribute("style") ?? "";
                        string newStyle = $"text-align:{alignValue};{existingStyle}";
                        element.SetAttribute("style", newStyle);
                    }
                    element.RemoveAttribute("align");
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