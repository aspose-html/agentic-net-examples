// Use ConvertHTML with ImageRenderingOptions to produce JPG files from a list of remote HTML URLs.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            List<string> urls = new List<string>
            {
                "https://example.com",
                "https://www.wikipedia.org"
            };

            string outputFolder = "Output";
            Directory.CreateDirectory(outputFolder);

            foreach (string url in urls)
            {
                using (HTMLDocument document = new HTMLDocument(url))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                    Uri uri = new Uri(url);
                    string fileName = Path.GetFileNameWithoutExtension(uri.AbsolutePath);
                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = "index";
                    }

                    string outputPath = Path.Combine(outputFolder, fileName + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}