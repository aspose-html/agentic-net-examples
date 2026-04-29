// Apply password protection to PDF output generated from MHTML using PdfSaveOptions encryption features.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input MHTML and output PDF
            string mhtmlPath = "input.mhtml";
            string outputPdfPath = "output.pdf";

            // Passwords for PDF encryption
            string userPassword = "user123";
            string ownerPassword = "owner123";

            // Open the MHTML file as a read‑only stream
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                // Configure PDF save options with encryption settings
                PdfSaveOptions options = new PdfSaveOptions
                {
                    Encryption = new PdfEncryptionInfo(
                        ownerPassword: ownerPassword,
                        userPassword: userPassword,
                        permissions: PdfPermissions.PrintDocument | PdfPermissions.ExtractContent,
                        encryptionAlgorithm: PdfEncryptionAlgorithm.RC4_128)
                };

                // Convert the MHTML stream to an encrypted PDF file
                Converter.ConvertMHTML(stream, options, outputPdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}