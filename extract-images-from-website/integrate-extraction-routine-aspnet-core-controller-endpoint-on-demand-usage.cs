// Integrate the extraction routine into an ASP.NET Core controller endpoint for on‑demand usage.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            const string inputMhtmlPath = "sample.mhtml";
            const string outputDocxPath = "output.docx";

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputMhtmlPath))
            {
                File.WriteAllText(inputMhtmlPath, string.Empty);
            }

            using (Stream inputStream = File.OpenRead(inputMhtmlPath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(inputStream);
                File.WriteAllBytes(outputDocxPath, docxBytes);
                Console.WriteLine($"DOCX file saved to: {outputDocxPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
        var options = new Aspose.Html.Saving.DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        return File.ReadAllBytes(tempDocxPath);
    }
}