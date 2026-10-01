// Configure PDF encryption password via PdfSaveOptions.Password to protect the generated PDF from unauthorized access.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.Encryption = new Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionInfo(
                ownerPassword: "owner123",
                userPassword: "user123",
                permissions: Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.PrintDocument | Aspose.Html.Rendering.Pdf.Encryption.PdfPermissions.ExtractContent,
                encryptionAlgorithm: Aspose.Html.Rendering.Pdf.Encryption.PdfEncryptionAlgorithm.RC4_128);
            string outputPath = "encrypted_output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            System.Console.WriteLine("PDF generated with encryption at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}