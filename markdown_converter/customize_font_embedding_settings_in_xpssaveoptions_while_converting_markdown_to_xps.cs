// Customize the font embedding settings in XpsSaveOptions while converting Markdown to XPS format.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.md";
            string savePath = "output.xps";

            using (HTMLDocument document = Converter.ConvertMarkdown(sourcePath))
            {
                XpsSaveOptions options = new XpsSaveOptions()
                {
                    HorizontalResolution = 300,
                    VerticalResolution = 300
                };

                Converter.ConvertHTML(document, options, savePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}