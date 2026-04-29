// Integrate MHTML to DOCX conversion into an ASP.NET MVC controller returning the file as a download.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source MHTML file
            string mhtmlPath = "sample.mhtml";

            // Open the MHTML file as a readable stream
            using (FileStream inputStream = File.OpenRead(mhtmlPath))
            {
                // Convert the MHTML stream to DOCX bytes
                byte[] docxBytes = ConvertMhtmlToDocxBytes(inputStream);

                // Save the resulting DOCX bytes to a file for demonstration
                string outputDocxPath = "output.docx";
                File.WriteAllBytes(outputDocxPath, docxBytes);

                Console.WriteLine($"Conversion successful. DOCX saved to: {outputDocxPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Helper method that converts an MHTML stream to DOCX and returns the DOCX as a byte array
    static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        // Create a temporary file path for the intermediate DOCX file
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");

        // Configure DOCX saving options (default settings)
        DocSaveOptions options = new DocSaveOptions();

        // Perform the conversion: MHTML stream -> DOCX file
        Converter.ConvertMHTML(inputStream, options, tempDocxPath);

        // Read the generated DOCX file into a byte array
        byte[] result = File.ReadAllBytes(tempDocxPath);

        // Optionally delete the temporary file
        try { File.Delete(tempDocxPath); } catch { }

        return result;
    }
}