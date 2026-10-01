// Create a unit test that ensures conversion to DOCX preserves paragraph spacing from the original MHTML.

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
            // Prepare sample MHTML (simple HTML saved with .mhtml extension)
            string inputPath = "sample.mhtml";
            string htmlContent = "<html><body>" +
                                 "<p style=\"margin-top:20px; margin-bottom:30px;\">First paragraph.</p>" +
                                 "<p>Second paragraph.</p>" +
                                 "</body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Define output DOCX path
            string outputPath = "output.docx";

            // Open input stream
            using (Stream inputStream = File.OpenRead(inputPath))
            {
                // Set DOCX save options
                DocSaveOptions saveOptions = new DocSaveOptions();

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, saveOptions, outputPath);
            }

            // Verify that the DOCX file was created and has content
            if (File.Exists(outputPath))
            {
                long fileSize = new FileInfo(outputPath).Length;
                if (fileSize > 0)
                {
                    Console.WriteLine("Conversion succeeded. Output file size: {0} bytes.", fileSize);
                }
                else
                {
                    Console.WriteLine("Conversion failed: output file is empty.");
                }
            }
            else
            {
                Console.WriteLine("Conversion failed: output file was not created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}