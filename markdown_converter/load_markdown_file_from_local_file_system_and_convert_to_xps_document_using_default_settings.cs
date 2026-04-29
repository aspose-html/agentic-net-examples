// Load a Markdown file from the local file system and convert it to an XPS document using default settings.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MarkdownToXps
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.md";
                string code = "# Hello World\nThis is a markdown file.";
                string savePath = "output.xps";

                File.WriteAllText(sourcePath, code);

                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
                XpsSaveOptions options = new XpsSaveOptions();
                Converter.ConvertHTML(document, options, savePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}