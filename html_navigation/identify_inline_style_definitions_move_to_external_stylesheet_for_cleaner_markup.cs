// Identify inline style definitions and move them to an external stylesheet for cleaner markup.

using System;
using System.Linq;
using System.Text;
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

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Dom.Element style = document.CreateElement("style");

            var elementsWithStyle = document.QuerySelectorAll("[style]");
            int index = 0;
            StringBuilder cssBuilder = new StringBuilder();

            foreach (Aspose.Html.Dom.Element el in elementsWithStyle)
            {
                string inlineStyle = el.GetAttribute("style");
                if (!string.IsNullOrEmpty(inlineStyle))
                {
                    string className = $"inlineStyle{index}";
                    string existingClass = el.GetAttribute("class");
                    string newClass = string.IsNullOrEmpty(existingClass) ? className : existingClass + " " + className;
                    el.SetAttribute("class", newClass);
                    cssBuilder.AppendLine($".{className} {{ {inlineStyle} }}");
                    el.RemoveAttribute("style");
                    index++;
                }
            }

            style.TextContent = cssBuilder.ToString();

            Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)document.GetElementsByTagName("head").First();
            head.AppendChild(style);

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}