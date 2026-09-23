// Apply a naming pattern that prefixes each saved file with the source domain name.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Input files
            string[] inputs = new string[] { "sample1.html", "sample2.html" };

            // Create minimal sample HTML files if they do not exist
            if (!File.Exists(inputs[0]))
                File.WriteAllText(inputs[0], "<html><body><h1>Sample 1</h1></body></html>");
            if (!File.Exists(inputs[1]))
                File.WriteAllText(inputs[1], "<html><body><h1>Sample 2</h1></body></html>");

            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];

                using (var document = new Aspose.Html.HTMLDocument(inputPath, Directory.GetCurrentDirectory()))
                {
                    // Configure image options
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Determine domain name for prefix
                    string domain;
                    Uri uri = new Uri(Path.GetFullPath(inputPath), UriKind.Absolute);
                    if (uri.IsAbsoluteUri && !string.IsNullOrEmpty(uri.Host))
                        domain = uri.Host;
                    else
                        domain = "local";

                    string outputFileName = $"{domain}_{Path.GetFileNameWithoutExtension(inputPath)}.jpg";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Convert
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}