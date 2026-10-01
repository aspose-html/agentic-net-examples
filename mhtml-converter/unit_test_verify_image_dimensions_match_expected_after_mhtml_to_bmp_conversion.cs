// Develop a unit test that verifies the image dimensions match expected values after MHTML to BMP conversion.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.mht";
                string outputPath = "output.bmp";

                if (!System.IO.File.Exists(inputPath))
                {
                    string mhtmlContent = "From: <Saved by WebKit>\nSubject: \nDate: \nMIME-Version: 1.0\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\n\n------=_NextPart_000_0000\nContent-Type: text/html; charset=\"utf-8\"\nContent-Transfer-Encoding: quoted-printable\n\n<html><body><h1>Hello</h1></body></html>\n------=_NextPart_000_0000--";
                    System.IO.File.WriteAllText(inputPath, mhtmlContent);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                    options.UseAntialiasing = false;
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(Aspose.Html.Drawing.Length.FromPixels(400), Aspose.Html.Drawing.Length.FromPixels(300)));
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                VerifyImageDimensions(outputPath, 400, 300);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }

        static void VerifyImageDimensions(string imagePath, int expectedWidth, int expectedHeight)
        {
            using (System.Drawing.Image img = System.Drawing.Image.FromFile(imagePath))
            {
                if (img.Width == expectedWidth && img.Height == expectedHeight)
                {
                    System.Console.WriteLine("Image dimensions are as expected: " + img.Width + "x" + img.Height);
                }
                else
                {
                    System.Console.WriteLine($"Image dimensions mismatch. Expected: {expectedWidth}x{expectedHeight}, Actual: {img.Width}x{img.Height}");
                }
            }
        }
    }
}