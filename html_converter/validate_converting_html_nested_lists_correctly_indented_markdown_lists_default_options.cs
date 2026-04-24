// Validate that converting HTML with nested lists produces correctly indented Markdown list structures using default options.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToMarkdownValidation
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "nested.html";
                string mdPath = "nested.md";
                string htmlContent = "<ul><li>Item 1<ul><li>Subitem 1</li><li>Subitem 2</li></ul></li><li>Item 2</li></ul>";
                File.WriteAllText(htmlPath, htmlContent);
                MarkdownSaveOptions options = new MarkdownSaveOptions();
                Converter.ConvertHTML(htmlPath, options, mdPath);
                string markdown = File.ReadAllText(mdPath);
                Console.WriteLine("Converted Markdown:");
                Console.WriteLine(markdown);
                string[] lines = markdown.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                bool valid = true;
                foreach (string line in lines)
                {
                    if (line.StartsWith("- "))
                        continue;
                    if (line.StartsWith("  - "))
                        continue;
                    valid = false;
                    break;
                }
                Console.WriteLine(valid ? "Validation passed." : "Validation failed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}