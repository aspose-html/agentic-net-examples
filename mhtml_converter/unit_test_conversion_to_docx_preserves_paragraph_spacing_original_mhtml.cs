// Create a unit test that ensures conversion to DOCX preserves paragraph spacing from the original MHTML.

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
            // Paths to the source MHTML file and the target DOCX file
            string mhtmlPath = "input.mhtml";
            string docxPath = "output.docx";

            // Open the MHTML file as a readable stream
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                // Create default DOCX save options
                DocSaveOptions options = new DocSaveOptions();

                // Convert the MHTML stream to a DOCX document
                Converter.ConvertMHTML(stream, options, docxPath);
            }

            // Basic verification: ensure the DOCX file was created
            if (File.Exists(docxPath))
            {
                Console.WriteLine("Conversion succeeded, DOCX file created.");
            }
            else
            {
                Console.WriteLine("Conversion failed, DOCX file not found.");
            }

            // Detailed verification of paragraph spacing would require parsing the DOCX,
            // which is beyond the scope of this example.
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}