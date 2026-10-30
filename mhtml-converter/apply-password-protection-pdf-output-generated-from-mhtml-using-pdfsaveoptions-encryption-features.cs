// Apply password protection to PDF output generated from MHTML using PdfSaveOptions encryption features.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string mhtmlContent = "<html><body><h1>Hello MHTML</h1></body></html>";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure PDF save options with encryption
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions
                {
                    Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                        ownerPassword: "owner123",
                        userPassword: "user123",
                        permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument |
                                     Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.ExtractContent,
                        encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128)
                };

                // Convert MHTML to encrypted PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("PDF conversion completed successfully. Encrypted file saved at:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}