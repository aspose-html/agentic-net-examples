// Configure PdfSaveOptions to disable PDF/A compliance when converting MHTML for regular PDF output.

namespace AsposeHtmlMhtmlToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mhtml";
                string outputPath = "output.pdf";

                if (!System.IO.File.Exists(inputPath))
                {
                    string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                    System.IO.File.WriteAllText(inputPath, htmlContent);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    // PDF/A compliance is not enabled by default; no additional configuration needed.
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("MHTML converted to PDF successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}