// Write code to convert MHTML to XPS and then extract the XPS package contents for analysis.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.mht");
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output.xps");

                if (!System.IO.File.Exists(inputPath))
                {
                    string mhtmlContent = "From: <saved by example>\r\nSubject: Test\r\nMIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello World</h1></body></html>\r\n------=_NextPart_000_0000--";
                    System.IO.File.WriteAllText(inputPath, mhtmlContent);
                }

                using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                using (System.IO.Compression.ZipArchive archive = System.IO.Compression.ZipFile.OpenRead(outputPath))
                {
                    System.Console.WriteLine("XPS package entries:");
                    foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                    {
                        System.Console.WriteLine(entry.FullName);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}