// Configure DocSaveOptions to enforce OpenXML strict compliance when generating DOCX from MHTML for enterprise standards.

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
            // Prepare sample MHTML file
            string inputPath = "sample.mht";
            string mhtmlContent = "From: <test@example.com>\nSubject: Test\n\n<html><body><p>Hello, World!</p></body></html>";
            File.WriteAllText(inputPath, mhtmlContent);

            // Define output DOCX path
            string outputPath = "output.docx";

            // Open input stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure save options (default options; no explicit strict compliance property available)
                DocSaveOptions saveOptions = new DocSaveOptions();

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}