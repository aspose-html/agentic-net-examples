// Render an MHTML email archive to PDF while preserving embedded images and styles.

namespace AsposeHtmlMhtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.mhtml");
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.pdf");

                if (!System.IO.File.Exists(inputPath))
                {
                    string mhtmlContent = "From: example@example.com\r\nSubject: Test\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello</h1><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAn8B9pV6WQAAAABJRU5ErkJggg==\"/></body></html>\r\n------=_NextPart_000_0000--";
                    System.IO.File.WriteAllText(inputPath, mhtmlContent);
                }

                using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed. PDF saved to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}