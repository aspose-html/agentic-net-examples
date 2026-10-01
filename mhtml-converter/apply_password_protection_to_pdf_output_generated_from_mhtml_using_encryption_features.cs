// Apply password protection to PDF output generated from MHTML using PdfSaveOptions encryption features.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf.Encryption;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                options.Encryption = new PdfEncryptionInfo(
                    "owner_pwd",
                    "user_pwd",
                    PdfPermissions.PrintDocument,
                    PdfEncryptionAlgorithm.RC4_128);

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("PDF generated with password protection at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}