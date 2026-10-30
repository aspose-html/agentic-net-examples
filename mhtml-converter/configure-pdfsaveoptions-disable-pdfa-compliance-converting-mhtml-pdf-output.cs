// Configure PdfSaveOptions to disable PDF/A compliance when converting MHTML for regular PDF output.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace AsposeHtmlMhtmlToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.pdf";

                // Ensure the sample MHTML file exists; create a minimal one if needed
                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content.</p></body></html>");
                }

                using (Stream stream = File.OpenRead(inputPath))
                {
                    PdfSaveOptions options = new PdfSaveOptions();
                    // PDF/A compliance is disabled by default for regular PDF output

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                Console.WriteLine("MHTML successfully converted to PDF: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conversion failed: " + ex.Message);
            }
        }
    }
}