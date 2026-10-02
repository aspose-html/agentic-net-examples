// Apply password protection to generated PDF by setting Permissions property in PdfSaveOptions.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var saveOptions = new Aspose.Html.Saving.PdfSaveOptions();
            saveOptions.Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                ownerPassword: "owner123",
                userPassword: "user123",
                permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument |
                             Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.ExtractContent,
                encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128
            );

            string outputPath = "protected.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, saveOptions, outputPath);

            Console.WriteLine("PDF generated with password protection.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}