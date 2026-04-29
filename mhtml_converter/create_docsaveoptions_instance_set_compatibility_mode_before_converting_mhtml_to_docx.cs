// Create a DocSaveOptions instance to set compatibility mode before converting MHTML to DOCX.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.docx";

            using (Stream stream = File.OpenRead(inputPath))
            {
                DocSaveOptions options = new DocSaveOptions();
                // Compatibility mode is not available in Aspose.Html's DocSaveOptions; proceeding without it.
                Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}