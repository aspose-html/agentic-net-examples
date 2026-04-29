// Configure DocSaveOptions to embed fonts in the DOCX output for consistent rendering across platforms.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Doc;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.docx";

            DocSaveOptions options = new DocSaveOptions();
            options.FontEmbeddingRule = FontEmbeddingRule.Full;

            Converter.ConvertHTML(inputPath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}