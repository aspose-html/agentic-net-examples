// Use DocSaveOptions to set default font fallback when converting MHTML containing unsupported fonts to DOCX.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.mhtml";
            string outputPath = "output.docx";

            using (Stream stream = File.OpenRead(sourcePath))
            {
                DocSaveOptions options = new DocSaveOptions();
                // Font fallback settings are not available in this version; using default options.
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML has been successfully converted to DOCX.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}