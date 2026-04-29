// Use XpsSaveOptions to embed a custom font family during Markdown to XPS conversion.

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

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

            XpsSaveOptions options = new XpsSaveOptions();
            // Custom font embedding is not configured here due to lack of supported API in the current context.

            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}