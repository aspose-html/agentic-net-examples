// Create a scheduled task that processes newly added HTML files, converting them to PDF nightly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            ConvertHtmlToPdfSample();

            string mhtmlFolder = Path.Combine(Directory.GetCurrentDirectory(), "MhtmlSamples");
            ConvertMhtmlFilesInFolder(mhtmlFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static void ConvertHtmlToPdfSample()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
        if (!File.Exists(inputPath))
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            File.WriteAllText(inputPath, htmlContent);
        }

        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.pdf");

        var options = new Aspose.Html.Saving.PdfSaveOptions();
        Aspose.Html.Converters.Converter.ConvertHTML(inputPath, options, outputPath);

        Console.WriteLine($"HTML file converted to PDF: {outputPath}");
    }

    private static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            // Create a minimal MHTML sample file
            string sampleMhtmlPath = Path.Combine(folderPath, "sample.mht");
            string mhtmlContent = @"From: <Saved by WebKit>
Subject: 
Date: Thu, 01 Jan 1970 00:00:00 GMT
MIME-Version: 1.0
Content-Type: multipart/related; boundary=""----=_NextPart_000_0000_01D4C0A0.00000000""; type=""text/html""

------=_NextPart_000_0000_01D4C0A0.00000000
Content-Type: text/html; charset=""utf-8""
Content-Transfer-Encoding: quoted-printable

<!DOCTYPE html>
<html>
<head><title>MHTML Sample</title></head>
<body><p>This is a sample MHTML file.</p></body>
</html>

------=_NextPart_000_0000_01D4C0A0.00000000--";
            File.WriteAllText(sampleMhtmlPath, mhtmlContent);
        }

        foreach (string mhtmlPath in Directory.GetFiles(folderPath, "*.mht"))
        {
            string outputPath = Path.ChangeExtension(mhtmlPath, ".pdf");
            var options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlPath, options, outputPath);
            Console.WriteLine($"MHTML file converted to PDF: {outputPath}");
        }
    }
}