// Apply password protection to PDF output generated from MHTML using PdfSaveOptions encryption features.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mht");
            string htmlContent = "<html><body><h1>Hello, MHTML!</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Set up PDF save options with encryption
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo encryptionInfo =
                new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                    "owner123",
                    "user123",
                    Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument,
                    Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);
            pdfOptions.Encryption = encryptionInfo;

            // Convert MHTML to encrypted PDF
            using (FileStream mhtmlStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, pdfOptions, outputPath);
            }

            Console.WriteLine("PDF generated with password protection at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}