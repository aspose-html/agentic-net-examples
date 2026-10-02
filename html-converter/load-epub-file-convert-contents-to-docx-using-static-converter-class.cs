// Load an EPUB file and convert its contents to DOCX using the static Converter class.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.epub";
            string outputPath = "sample.docx";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllBytes(sourcePath, new byte[0]);
            }

            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();

            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}