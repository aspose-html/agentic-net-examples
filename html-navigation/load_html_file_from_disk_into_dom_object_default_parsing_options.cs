// Load an HTML file from disk into a DOM object using default parsing options.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, Aspose!</p></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            string html = document.DocumentElement.OuterHTML;
            Console.WriteLine("Loaded HTML:");
            Console.WriteLine(html);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}