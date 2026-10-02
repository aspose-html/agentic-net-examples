// Enable compression of the HTML output to reduce file size for faster transmission.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            string outputPath = Path.Combine(Path.GetTempPath(), "sample_compressed.html");

            // Create a minimal HTML file.
            File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Load the HTML document from the file.
            HTMLDocument document = new HTMLDocument(inputPath);

            // Set up HTML save options (compression can be set if supported).
            HTMLSaveOptions options = new HTMLSaveOptions();
            // Example: options.Compression = Aspose.Html.Saving.Compression.GZip; // Uncomment if the property exists.

            // Save the document with the specified options.
            document.Save(outputPath, options);

            Console.WriteLine("HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}