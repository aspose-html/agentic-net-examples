// Convert multiple website URLs in batch mode, storing each result in separate HTML files.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string[] urls = new string[]
            {
                "https://www.example.com",
                "https://www.wikipedia.org"
            };

            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputFolder);

            for (int i = 0; i < urls.Length; i++)
            {
                string url = urls[i];
                using (HTMLDocument document = new HTMLDocument(url))
                {
                    string fileName = $"page_{i + 1}.html";
                    string outputPath = Path.Combine(outputFolder, fileName);
                    document.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}