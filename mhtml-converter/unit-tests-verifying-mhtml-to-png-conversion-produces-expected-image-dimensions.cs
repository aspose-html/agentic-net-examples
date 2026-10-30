// Write unit tests verifying that MHTML to PNG conversion produces an image with expected dimensions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string inputPath = "sample.mhtml";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><div style=""width:200px;height:100px;background:#ff0000;""></div></body></html>

------=_NextPart_000_0000--";
                File.WriteAllText(inputPath, mhtmlContent);
            }

            // Configure image save options with expected page size
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromPixels(200),
                    Aspose.Html.Drawing.Length.FromPixels(100)));
            options.UseAntialiasing = true;

            // Convert MHTML to PNG
            using (var stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            // Verify resulting image dimensions
            using (var image = Image.FromFile(outputPath))
            {
                int expectedWidth = 200;
                int expectedHeight = 100;

                if (image.Width != expectedWidth || image.Height != expectedHeight)
                {
                    throw new Exception($"Image dimensions mismatch. Expected {expectedWidth}x{expectedHeight}, got {image.Width}x{image.Height}.");
                }
            }

            Console.WriteLine("MHTML to PNG conversion test passed. Image dimensions are as expected.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}