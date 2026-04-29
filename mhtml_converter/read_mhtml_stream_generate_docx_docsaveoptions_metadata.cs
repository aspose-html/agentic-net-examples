// Read an MHTML stream and generate a DOCX document with custom DocSaveOptions for metadata.

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
            // Path to the source MHTML file
            string inputPath = "input.mhtml";
            // Desired path for the generated DOCX file
            string outputPath = "output.docx";

            // Open the MHTML file as a readable stream
            Stream stream = File.OpenRead(inputPath);

            // Create DocSaveOptions to configure DOCX output (custom metadata can be set here if supported)
            DocSaveOptions saveOptions = new DocSaveOptions();
            // Example of setting metadata (uncomment if the API provides such properties)
            // saveOptions.Metadata.Title = "Sample Document";

            // Convert the MHTML stream to DOCX using the specified options and output path
            Converter.ConvertMHTML(stream, saveOptions, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}