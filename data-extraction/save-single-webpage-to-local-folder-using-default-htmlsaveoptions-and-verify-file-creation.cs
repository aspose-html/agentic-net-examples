// Save a single webpage to a local folder with default HTMLSaveOptions and verify file creation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the webpage to download
            string url = "https://example.com";

            // Load the webpage
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);

            // Prepare output path
            string outputDirectory = Path.Combine(Environment.CurrentDirectory, "Output");
            Directory.CreateDirectory(outputDirectory);
            string outputPath = Path.Combine(outputDirectory, "example.html");

            // Use default HTML save options
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save the document
            document.Save(outputPath, options);

            // Verify file creation
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"Webpage saved successfully to: {outputPath}");
            }
            else
            {
                Console.WriteLine("Failed to save the webpage.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}