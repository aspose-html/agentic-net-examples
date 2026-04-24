// Add a CLI flag to skip downloading files that already exist in the output directory.

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
            // Expect at least URL and output path arguments
            if (args.Length < 2)
                return;

            string url = args[0];
            string outputPath = args[1];
            bool skipExisting = false;

            // Detect optional flag to skip existing files
            foreach (var arg in args)
            {
                if (arg.Equals("--skip-existing", StringComparison.OrdinalIgnoreCase))
                {
                    skipExisting = true;
                    break;
                }
            }

            // If flag is set and file already exists, skip download
            if (skipExisting && File.Exists(outputPath))
                return;

            // Load the website into an HTMLDocument
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url);

            // Configure save options to embed JavaScript resources
            Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
            options.ResourceHandlingOptions.JavaScript = Aspose.Html.Saving.ResourceHandling.Embed;

            // Save the downloaded HTML to the specified path
            document.Save(outputPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}