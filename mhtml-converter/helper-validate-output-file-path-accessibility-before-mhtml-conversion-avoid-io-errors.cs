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
            string baseUri = "about:blank";

            // Desired output MHTML file path
            string outputPath = "output/sample.mhtml";

            // Validate output path accessibility
            if (!IsOutputPathWritable(outputPath))
            {
                throw new IOException($"Cannot write to the specified output path: {outputPath}");
            }

            // Set MHTML save options (default options are sufficient for this example)
            MHTMLSaveOptions options = new MHTMLSaveOptions();

            // Perform conversion from HTML string to MHTML file
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);

            Console.WriteLine($"Conversion succeeded. MHTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static bool IsOutputPathWritable(string path)
    {
        try
        {
            string directory = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(directory))
                return false;

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // Attempt to create (or overwrite) the file to ensure write access, then delete it.
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                // No need to write anything; just opening the file is enough to test write permission.
            }

            // Optionally delete the empty file; conversion will recreate it.
            if (File.Exists(path))
                File.Delete(path);

            return true;
        }
        catch
        {
            return false;
        }
    }
}