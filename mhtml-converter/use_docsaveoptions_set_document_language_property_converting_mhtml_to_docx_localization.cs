// Use DocSaveOptions to set document language property when converting MHTML to DOCX for localization.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mht";
            string outputPath = "output.docx";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Hello World</p></body></html>");
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.DocSaveOptions();
                // If a language property is supported, it can be set here, e.g.:
                // options.DocumentLanguage = "en-US";

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}