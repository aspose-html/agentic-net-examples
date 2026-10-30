// Customize the font embedding settings in XpsSaveOptions while converting Markdown to XPS format.

using System;
using System.IO;
using System.Drawing;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.md";
                string savePath = "output.xps";

                if (!File.Exists(sourcePath))
                {
                    File.WriteAllText(sourcePath, "# Sample Title\n\nThis is a sample markdown content.");
                }

                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = Color.White;
                // Font embedding settings are not available in the current API version.

                Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);

                Console.WriteLine($"Markdown converted to XPS successfully: {savePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}