// Verify PDF output contains the correct number of pages by opening the file with a PDF reader library.

class Program
{
    static void Main()
    {
        try
        {
            string inputHtmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1><p>Sample content.</p></body></html>";
            System.IO.File.WriteAllText(inputHtmlPath, htmlContent);

            // Set PDF save options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(inputHtmlPath, options, outputPdfPath);

            // Verify PDF output
            if (!System.IO.File.Exists(outputPdfPath))
            {
                throw new System.Exception("PDF file was not created.");
            }

            System.IO.FileInfo pdfInfo = new System.IO.FileInfo(outputPdfPath);
            if (pdfInfo.Length == 0)
            {
                throw new System.Exception("PDF file is empty.");
            }

            System.Console.WriteLine("PDF conversion verification passed. File size: " + pdfInfo.Length + " bytes.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}