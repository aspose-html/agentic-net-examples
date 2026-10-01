// Create a helper that validates output file path accessibility before invoking MHTML conversion to avoid I/O errors.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content and base URI
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "http://example.com/";
            string outputPath = "output/sample.mhtml";

            // Validate output path accessibility
            if (!IsPathWritable(outputPath))
            {
                Console.Error.WriteLine($"Cannot write to the specified output path: {outputPath}");
                return;
            }

            // Set MHTML save options (default options)
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"MHTML file successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private static bool IsPathWritable(string path)
    {
        try
        {
            string directory = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(directory))
                directory = Directory.GetCurrentDirectory();

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // Attempt to create and delete a temporary file
            string tempFile = Path.Combine(directory, Path.GetRandomFileName());
            using (FileStream fs = new FileStream(tempFile, FileMode.Create, FileAccess.Write))
            {
            }
            File.Delete(tempFile);
            return true;
        }
        catch
        {
            return false;
        }
    }
}