// Save a single webpage to a local folder with default HTMLSaveOptions and verify file creation.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL of the webpage to save
            string url = "https://www.example.com";

            // Local path where the HTML file will be saved
            string outputPath = "saved_page.html";

            // Load the webpage into an HTMLDocument
            HTMLDocument document = new HTMLDocument(url);

            // Create default HTML save options
            HTMLSaveOptions options = new HTMLSaveOptions();

            // Set handling depth to default (0) to process only the root page
            options.ResourceHandlingOptions.MaxHandlingDepth = 0;

            // Save the document to the specified path with the options
            document.Save(outputPath, options);

            // Verify that the file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine($"Webpage saved successfully to '{outputPath}'.");
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