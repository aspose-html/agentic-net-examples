// Integrate the conversion library into an ASP.NET MVC application for on‑demand website rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><p>Hello MHTML</p></body></html>");
            }

            using (FileStream stream = File.OpenRead(sourcePath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(stream);
                string outputPath = "output.docx";
                File.WriteAllBytes(outputPath, docxBytes);
                Console.WriteLine($"DOCX file saved to {outputPath}");
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
        Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        return File.ReadAllBytes(tempDocxPath);
    }
}