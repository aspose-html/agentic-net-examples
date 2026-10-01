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
            TestMhtmlToPngConversion();
            Console.WriteLine("Test passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void TestMhtmlToPngConversion()
    {
        // Define paths
        string tempFolder = Path.Combine(Path.GetTempPath(), "AsposeHtmlMhtmlTest");
        Directory.CreateDirectory(tempFolder);
        string mhtmlPath = Path.Combine(tempFolder, "sample.mhtml");
        string pngPath = Path.Combine(tempFolder, "output.png");

        // Create a minimal MHTML file
        string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: 
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000""

------=_NextPart_000_0000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<html><body><h1>Hello World</h1></body></html>
------=_NextPart_000_0000--";
        File.WriteAllText(mhtmlPath, mhtmlContent);

        // Set expected dimensions
        int expectedWidth = 800;
        int expectedHeight = 600;

        // Prepare conversion options
        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
        options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
            new Aspose.Html.Drawing.Size(
                Aspose.Html.Drawing.Length.FromPixels(expectedWidth),
                Aspose.Html.Drawing.Length.FromPixels(expectedHeight)));

        // Perform conversion
        using (Stream stream = File.OpenRead(mhtmlPath))
        {
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pngPath);
        }

        // Verify the resulting PNG dimensions
        using (Image img = Image.FromFile(pngPath))
        {
            if (img.Width != expectedWidth || img.Height != expectedHeight)
            {
                throw new InvalidOperationException($"Image dimensions mismatch. Expected {expectedWidth}x{expectedHeight}, got {img.Width}x{img.Height}.");
            }
        }

        // Cleanup (optional)
        // File.Delete(mhtmlPath);
        // File.Delete(pngPath);
        // Directory.Delete(tempFolder);
    }
}