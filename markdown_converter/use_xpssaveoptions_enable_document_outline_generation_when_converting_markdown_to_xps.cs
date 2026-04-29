// Use XpsSaveOptions to enable document outline generation when converting Markdown to XPS.

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
            string outputPath = "output.xps";

            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
            XpsSaveOptions options = new XpsSaveOptions();

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}