// Use XpsSaveOptions to set page size before converting a Markdown file to an XPS document.

using System;
using System.IO;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.md";
                string outputPath = "output.xps";

                if (!File.Exists(sourcePath))
                {
                    File.WriteAllText(sourcePath, "# Sample Markdown\n\nThis is a test.");
                }

                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page()
                {
                    Size = new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(600))
                };
                options.BackgroundColor = Color.White;

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed. XPS saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}