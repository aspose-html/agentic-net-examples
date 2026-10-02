// Convert task list items to regular bullet points to simplify document formatting.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string sourcePath = "input.md";
            string markdownContent = "- [ ] Task one\n- [x] Task two\n- Regular item";
            File.WriteAllText(sourcePath, markdownContent);

            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            var checkboxes = document.QuerySelectorAll("input[type=checkbox]");
            foreach (Aspose.Html.Dom.Element cb in checkboxes)
            {
                if (cb.ParentNode != null)
                {
                    cb.ParentNode.RemoveChild(cb);
                }
            }

            Aspose.Html.Saving.MarkdownSaveOptions saveOptions = new Aspose.Html.Saving.MarkdownSaveOptions();
            saveOptions.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            string outputPath = "output.md";
            document.Save(outputPath, saveOptions);

            Console.WriteLine("Conversion completed. Output saved at " + outputPath);
            Console.WriteLine("Resulting markdown:");
            Console.WriteLine(File.ReadAllText(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}