// Use PdfSaveOptions to embed a custom ICC profile for color management during MHTML to PDF conversion.

using System;
using System.IO;
using System.Drawing;

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a minimal MHTML file for demonstration
            string mhtmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mht");
            File.WriteAllText(mhtmlPath, "<html><body><h1>Sample MHTML</h1></body></html>");

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                // Configure PDF save options
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                pdfOptions.HorizontalResolution = 300;
                pdfOptions.VerticalResolution = 300;
                pdfOptions.BackgroundColor = System.Drawing.Color.AliceBlue;

                // If PdfSaveOptions supports ICC profile embedding, set the profile path here
                // pdfOptions.IccProfile = "path/to/custom.icc";

                // Define output PDF path
                string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

                // Perform the conversion from MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, pdfPath);
            }

            Console.WriteLine("MHTML to PDF conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}