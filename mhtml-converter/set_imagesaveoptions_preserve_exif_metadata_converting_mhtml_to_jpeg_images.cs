// Set ImageSaveOptions to preserve EXIF metadata when converting MHTML to JPEG images.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "sample.mhtml";
                string outputPath = "output.jpg";

                if (!System.IO.File.Exists(sourcePath))
                {
                    string mhtmlContent = @"From: <Saved by WebKit>
Subject: Sample MHTML
Date: Thu, 1 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello, MHTML!</h1></body></html>

------=_NextPart_000_0000--";
                    System.IO.File.WriteAllText(sourcePath, mhtmlContent);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion completed successfully.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}