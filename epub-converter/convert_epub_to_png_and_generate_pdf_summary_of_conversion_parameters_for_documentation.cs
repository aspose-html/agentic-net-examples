// Convert EPUB to PNG and simultaneously generate a PDF summary of conversion parameters for documentation purposes.

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
            string dataDir = "Data";
            string outputDir = "Output";
            System.IO.Directory.CreateDirectory(dataDir);
            System.IO.Directory.CreateDirectory(outputDir);
            string epubPath = System.IO.Path.Combine(dataDir, "sample.epub");
            if (!System.IO.File.Exists(epubPath))
            {
                System.IO.File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Convert EPUB to PNG
            using (System.IO.FileStream epubStream = System.IO.File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.ImageSaveOptions imageOptions = new Aspose.Html.Saving.ImageSaveOptions();
                imageOptions.HorizontalResolution = 300;
                imageOptions.VerticalResolution = 300;
                string pngPath = System.IO.Path.Combine(outputDir, "output.png");
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, imageOptions, pngPath);
            }

            // Convert EPUB to PDF (summary)
            using (System.IO.FileStream epubStream2 = System.IO.File.OpenRead(epubPath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = System.IO.Path.Combine(outputDir, "summary.pdf");
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream2, pdfOptions, pdfPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}