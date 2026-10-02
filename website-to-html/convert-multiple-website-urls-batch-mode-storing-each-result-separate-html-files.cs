// Convert multiple website URLs in batch mode, storing each result in separate HTML files.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            string[] urls = new string[] { "https://example.com", "https://example.org" };

            for (int i = 0; i < urls.Length; i++)
            {
                using (var document = new Aspose.Html.HTMLDocument(urls[i]))
                {
                    string outputPath = System.IO.Path.Combine(outputDir, $"page_{i + 1}.html");
                    document.Save(outputPath);
                }
            }

            System.Console.WriteLine("Conversion completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}