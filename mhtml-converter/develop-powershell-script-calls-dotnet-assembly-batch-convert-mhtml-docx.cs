// Develop a PowerShell script that calls the .NET assembly to batch convert MHTML files to DOCX.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input MHTML file path (hard‑coded for the example)
            string inputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample.mhtml");
            // Output DOCX file path
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.docx");

            // Ensure the input file exists; create a minimal placeholder if it does not.
            if (!File.Exists(inputPath))
            {
                // Create a very simple HTML file and rename it to .mhtml for demonstration purposes.
                string simpleHtml = "<html><body><h1>Sample MHTML Content</h1></body></html>";
                File.WriteAllText(inputPath, simpleHtml);
            }

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(inputStream);
                File.WriteAllBytes(outputPath, docxBytes);
            }

            Console.WriteLine($"Conversion completed successfully. DOCX saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method that converts an MHTML stream to a DOCX byte array.
    static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        // Create a temporary file path for the intermediate DOCX.
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");

        // Set up DOCX save options.
        var options = new Aspose.Html.Saving.DocSaveOptions();

        // Perform the conversion.
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);

        // Read the resulting DOCX file into a byte array.
        byte[] result = File.ReadAllBytes(tempDocxPath);

        // Optionally delete the temporary file.
        try { File.Delete(tempDocxPath); } catch { }

        return result;
    }
}