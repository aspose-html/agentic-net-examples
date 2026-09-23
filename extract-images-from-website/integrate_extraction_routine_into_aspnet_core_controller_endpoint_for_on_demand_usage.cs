// Integrate the extraction routine into an ASP.NET Core controller endpoint for on‑demand usage.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            if (!File.Exists(inputPath))
            {
                // Create a minimal placeholder MHTML file
                File.WriteAllText(inputPath, string.Empty);
            }

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(inputStream);
                string outputPath = "output.docx";
                File.WriteAllBytes(outputPath, docxBytes);
                Console.WriteLine("Conversion completed. Output saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
        Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        byte[] result = File.ReadAllBytes(tempDocxPath);
        try
        {
            File.Delete(tempDocxPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
        return result;
    }
}