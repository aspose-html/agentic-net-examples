// Implement a feature that allows users to select multiple MHTML files and convert them to a single PDF document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define input MHTML files (hardcoded for the example)
            string[] mhtmlFiles = new string[]
            {
                System.IO.Path.Combine("InputFiles", "sample1.mhtml"),
                System.IO.Path.Combine("InputFiles", "sample2.mhtml")
            };

            // Ensure the input directory exists (create minimal sample files if missing)
            string inputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InputFiles");
            if (!System.IO.Directory.Exists(inputDir))
                System.IO.Directory.CreateDirectory(inputDir);

            // Create minimal sample MHTML files if they do not exist
            foreach (var file in mhtmlFiles)
            {
                if (!System.IO.File.Exists(file))
                {
                    // Simple MHTML content with a basic HTML body
                    string minimalMhtml = "From: <Saved by WebKit>\nSubject: Sample MHTML\nDate: Thu, 1 Jan 1970 00:00:00 GMT\nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><h1>Sample MHTML</h1></body></html>\n------=_NextPart_000_0000--";
                    System.IO.File.WriteAllText(file, minimalMhtml);
                }
            }

            // Output PDF path (single PDF that would contain all pages)
            string outputPdf = System.IO.Path.Combine("Output", "Combined.pdf");
            string outputDir = System.IO.Path.GetDirectoryName(outputPdf);
            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            // Convert each MHTML to a temporary PDF
            var tempPdfFiles = new System.Collections.Generic.List<string>();
            foreach (var mhtmlPath in mhtmlFiles)
            {
                string tempPdf = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(mhtmlPath) + "_temp.pdf");
                using (System.IO.Stream stream = System.IO.File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, tempPdf);
                }
                tempPdfFiles.Add(tempPdf);
                Console.WriteLine($"Converted '{mhtmlPath}' to temporary PDF '{tempPdf}'.");
            }

            // NOTE: Merging multiple PDFs into a single document is not supported by Aspose.HTML.
            // To produce a combined PDF, an additional PDF manipulation library would be required.
            // For this example, the individual PDFs are generated separately.

            Console.WriteLine("Conversion completed. Individual PDF files are located in the Output folder.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}