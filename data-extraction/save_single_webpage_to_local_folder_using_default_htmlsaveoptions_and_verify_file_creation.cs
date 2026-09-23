// Save a single webpage to a local folder with default HTMLSaveOptions and verify file creation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output directories
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Define file paths
            string inputFile = Path.Combine(inputFolder, "sample.html");
            string outputFile = Path.Combine(outputFolder, "saved.html");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputFile))
            {
                File.WriteAllText(inputFile, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>");
            }

            // Load the webpage
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputFile);

            // Use default HTML save options
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save the document to the output path
            document.Save(outputFile, options);

            // Verify that the file was created
            if (File.Exists(outputFile))
            {
                Console.WriteLine("File saved successfully: " + outputFile);
            }
            else
            {
                Console.WriteLine("Failed to save the file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}