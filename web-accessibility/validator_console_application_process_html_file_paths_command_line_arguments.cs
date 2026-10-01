// Use the validator in a console application to process a list of HTML file paths via command‑line arguments.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] files = args.Length > 0 ? args : new string[] { "sample.html" };
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>");
                }

                using (HTMLDocument document = new HTMLDocument(filePath))
                {
                    // Placeholder for validation or processing logic
                    Console.WriteLine($"Processed: {filePath}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}