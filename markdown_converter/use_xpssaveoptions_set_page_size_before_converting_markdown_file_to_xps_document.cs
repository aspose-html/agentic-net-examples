// Use XpsSaveOptions to set page size before converting a Markdown file to an XPS document.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;

namespace MarkdownToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = "input.md";
                string savePath = "output.xps";

                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                XpsSaveOptions options = new XpsSaveOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromInches(8.5),
                        Length.FromInches(11)),
                    new Margin(0, 0, 0, 0));

                Converter.ConvertHTML(document, options, savePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}