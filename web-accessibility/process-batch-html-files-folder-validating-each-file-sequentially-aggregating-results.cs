// Process a batch of HTML files in a folder, validating each file sequentially and aggregating results.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputImages";
            Directory.CreateDirectory(outputFolder);

            int total = 0;
            int success = 0;
            int failure = 0;
            List<string> errorMessages = new List<string>();

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                total++;
                try
                {
                    using (HTMLDocument document = new HTMLDocument(htmlPath))
                    {
                        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                        string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    }
                    success++;
                }
                catch (Exception ex)
                {
                    failure++;
                    errorMessages.Add($"File '{htmlPath}' error: {ex.Message}");
                }
            }

            Console.WriteLine($"Processed {total} files. Success: {success}, Failed: {failure}.");
            if (errorMessages.Count > 0)
            {
                Console.WriteLine("Errors:");
                foreach (string msg in errorMessages)
                {
                    Console.WriteLine(msg);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}