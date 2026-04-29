// Convert existing Markdown tables into plain text representations while preserving column alignment.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MarkdownTableToPlainText
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "input.md";
                string htmlPath = "temp.html";
                string outputPath = "output.txt";

                Converter.ConvertMarkdown(sourcePath, htmlPath);
                TextSaveOptions options = new TextSaveOptions();
                Converter.ConvertHTML(htmlPath, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}