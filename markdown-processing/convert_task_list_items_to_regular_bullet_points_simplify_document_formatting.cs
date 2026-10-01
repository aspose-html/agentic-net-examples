// Convert task list items to regular bullet points to simplify document formatting.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample markdown file with task list items
            string sourcePath = "input.md";
            string markdownContent = "- [ ] Task 1\n- [x] Task 2\n- Normal item";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert markdown to an HTML document
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Remove checkbox inputs from list items to turn them into regular bullets
            foreach (Element checkbox in document.QuerySelectorAll("li input[type=checkbox]"))
            {
                if (checkbox.ParentNode != null)
                {
                    checkbox.ParentNode.RemoveChild(checkbox);
                }
            }

            // Save the modified document back to markdown
            string outputPath = "output.md";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph;
            document.Save(outputPath, options);

            Console.WriteLine("Conversion completed. Markdown saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}