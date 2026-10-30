// Set a maximum file size limit for individual HTML outputs to manage storage constraints.

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
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";

            // Create HTML document from inline content
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Set save options (optional configuration)
            HTMLSaveOptions options = new HTMLSaveOptions();
            // Example: limit resource handling depth (not size)
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;

            // Output file path
            string outputPath = "output.html";

            // Save the document
            document.Save(outputPath, options);

            // Define maximum allowed file size (e.g., 100 KB)
            const long maxFileSizeBytes = 100 * 1024;

            // Check the saved file size
            FileInfo fileInfo = new FileInfo(outputPath);
            if (fileInfo.Length > maxFileSizeBytes)
            {
                // Remove the file if it exceeds the limit
                File.Delete(outputPath);
                Console.WriteLine($"File exceeded the size limit of {maxFileSizeBytes} bytes and was removed.");
            }
            else
            {
                Console.WriteLine($"File saved successfully. Size: {fileInfo.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}