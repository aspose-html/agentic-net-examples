// Integrate MHTML to DOCX conversion into an ASP.NET MVC controller returning the file as a download.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            const string inputPath = "sample.mhtml";
            const string outputPath = "output.docx";

            // Ensure sample input exists; create a minimal placeholder if missing
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<html><body><p>Sample MHTML content</p></body></html>");
            }

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(inputStream);
                File.WriteAllBytes(outputPath, docxBytes);
                Console.WriteLine($"Conversion succeeded. DOCX saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
        DocSaveOptions options = new DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        return File.ReadAllBytes(tempDocxPath);
    }
}