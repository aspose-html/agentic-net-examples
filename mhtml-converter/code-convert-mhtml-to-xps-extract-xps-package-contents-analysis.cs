// Write code to convert MHTML to XPS and then extract the XPS package contents for analysis.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";
            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string mhtmlPath = Path.Combine(inputDir, "sample.mht");
            if (!File.Exists(mhtmlPath))
            {
                string mhtmlContent = "From: <Saved by WebKit>\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello MHTML</h1></body></html>\r\n------=_NextPart_000_0000--";
                File.WriteAllText(mhtmlPath, mhtmlContent);
            }

            string xpsPath = Path.Combine(outputDir, "result.xps");
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, xpsPath);
            }

            using (ZipArchive archive = ZipFile.OpenRead(xpsPath))
            {
                Console.WriteLine("XPS package entries:");
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    Console.WriteLine(entry.FullName);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}