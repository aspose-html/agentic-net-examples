// Render HTML to XPS and then extract vector graphics for use in CAD applications.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string xpsPath = "output.xps";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, xpsPath);

            string outputDir = "ExtractedGraphics";
            Directory.CreateDirectory(outputDir);

            // An XPS file is an OPC (zip-based) package, so its per-page
            // vector graphics parts can be extracted with ZipArchive
            // directly, without the separate System.IO.Packaging assembly.
            using (ZipArchive archive = ZipFile.OpenRead(xpsPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".fpage", StringComparison.OrdinalIgnoreCase))
                    {
                        string fileName = Path.GetFileName(entry.FullName);
                        string destPath = Path.Combine(outputDir, fileName);
                        using (FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(fs);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
