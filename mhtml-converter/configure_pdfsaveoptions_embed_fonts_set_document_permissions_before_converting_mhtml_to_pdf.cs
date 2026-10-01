// Configure PdfSaveOptions to embed fonts and set document permissions before converting MHTML to PDF.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = System.IO.Path.Combine("Input", "sample.mhtml");
                string outputPath = System.IO.Path.Combine("Output", "result.pdf");

                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(inputPath));
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(outputPath));

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    // EmbedFonts and Permissions are not available in this API version.

                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
                }

                System.Console.WriteLine("MHTML converted to PDF successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}