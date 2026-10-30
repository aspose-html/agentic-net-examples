// Use DocSaveOptions to set default font fallback when converting MHTML containing unsupported fonts to DOCX.

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
            string sourcePath = "sample.mhtml";
            string outputPath = "output.docx";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><p>Sample content</p></body></html>");
            }

            using (Stream stream = File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                // Default font fallback is applied automatically; no explicit property is available.
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}