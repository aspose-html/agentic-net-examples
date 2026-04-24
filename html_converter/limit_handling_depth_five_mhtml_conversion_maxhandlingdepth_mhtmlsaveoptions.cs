// Limit handling depth to five in MHTML conversion by setting MaxHandlingDepth in MHTMLSaveOptions.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.mht";

            MHTMLSaveOptions options = new MHTMLSaveOptions();
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;

            Converter.ConvertHTML(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}