// Create a helper that validates output file path accessibility before invoking MHTML conversion to avoid I/O errors.

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
            // Sample HTML content and base URI
            string htmlContent = "<html><body><h1>Hello, Aspose!</h1></body></html>";
            string baseUri = "http://example.com";

            // Desired output MHTML file path
            string outputPath = "output.mht";

            // Validate that the output path is writable
            ValidateOutputPath(outputPath);

            // Prepare MHTML save options (default settings)
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Perform the conversion from HTML string to MHTML file
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ValidateOutputPath(string path)
    {
        // Ensure the directory exists
        string directory = Path.GetDirectoryName(Path.GetFullPath(path));
        if (string.IsNullOrEmpty(directory))
        {
            throw new ArgumentException("Invalid output path.");
        }

        if (!Directory.Exists(directory))
        {
            throw new DirectoryNotFoundException($"Directory does not exist: {directory}");
        }

        // Attempt to create (and immediately delete) a temporary file to verify write permission
        string tempFile = Path.Combine(directory, Path.GetRandomFileName());
        try
        {
            using (FileStream fs = new FileStream(tempFile, FileMode.CreateNew, FileAccess.Write))
            {
                // No write needed; just opening the file confirms write access
            }
        }
        finally
        {
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
    }
}