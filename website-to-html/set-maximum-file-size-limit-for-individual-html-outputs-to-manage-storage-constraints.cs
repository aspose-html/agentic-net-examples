// Set a maximum file size limit for individual HTML outputs to manage storage constraints.

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
            // Define input HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure save options (optional settings)
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            // Example of setting a resource handling option (not related to size)
            options.ResourceHandlingOptions.MaxHandlingDepth = 5;

            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Save the document
            document.Save(outputPath, options);

            // Define maximum allowed file size (e.g., 100 KB)
            long maxFileSizeBytes = 100 * 1024;

            // Check the size of the saved file
            FileInfo fileInfo = new FileInfo(outputPath);
            if (fileInfo.Length > maxFileSizeBytes)
            {
                // Delete the file if it exceeds the limit
                fileInfo.Delete();
                Console.WriteLine($"Saved file exceeded the maximum size of {maxFileSizeBytes} bytes and was removed.");
            }
            else
            {
                Console.WriteLine($"File saved successfully at '{outputPath}'. Size: {fileInfo.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}