// Apply a naming pattern that prefixes each saved file with the source domain name.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);

            // Input files
            string[] inputs = new string[] { "sample1.html", "sample2.html" };

            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];

                // Ensure sample input file exists (minimal content)
                if (!File.Exists(inputPath))
                {
                    File.WriteAllText(inputPath, "<html><body><h1>Sample</h1></body></html>");
                }

                using (var document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    // Configure image options
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;

                    // Determine domain prefix
                    string domain;
                    if (Uri.TryCreate(inputPath, UriKind.Absolute, out Uri uri) && uri.IsAbsoluteUri && !string.IsNullOrEmpty(uri.Host))
                    {
                        domain = uri.Host;
                    }
                    else
                    {
                        domain = "local";
                    }

                    string fileName = $"{domain}_{Path.GetFileNameWithoutExtension(inputPath)}.jpeg";
                    string outputPath = Path.Combine(outputDir, fileName);

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