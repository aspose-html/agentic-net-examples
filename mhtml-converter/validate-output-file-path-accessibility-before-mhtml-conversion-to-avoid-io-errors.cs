// Create a helper that validates output file path accessibility before invoking MHTML conversion to avoid I/O errors.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = "about:blank";
            string outputPath = "output.mhtml";

            if (!ValidateOutputPath(outputPath))
            {
                System.Console.WriteLine($"Cannot write to output path: {outputPath}");
                return;
            }

            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            System.Console.WriteLine($"MHTML file saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static bool ValidateOutputPath(string path)
    {
        try
        {
            string directory = System.IO.Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(directory))
            {
                directory = System.IO.Directory.GetCurrentDirectory();
            }

            if (!System.IO.Directory.Exists(directory))
            {
                return false;
            }

            // Attempt to create and delete a temporary file to verify write access
            using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
            {
            }
            System.IO.File.Delete(path);
            return true;
        }
        catch
        {
            return false;
        }
    }
}