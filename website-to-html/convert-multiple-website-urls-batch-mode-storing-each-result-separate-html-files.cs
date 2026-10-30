// Convert multiple website URLs in batch mode, storing each result in separate HTML files.

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

            // Input URLs
            string[] inputs = new string[]
            {
                "https://example.com",
                "https://www.wikipedia.org"
            };

            for (int i = 0; i < inputs.Length; i++)
            {
                string url = inputs[i];
                string outputPath = Path.Combine(outputDir, $"page{i + 1}.html");

                using (var document = new Aspose.Html.HTMLDocument(url))
                {
                    var options = new Aspose.Html.Saving.HTMLSaveOptions();
                    document.Save(outputPath, options);
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