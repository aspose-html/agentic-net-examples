// Load an HTML file from disk into a DOM object using default parsing options.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, Aspose.HTML!</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML file into a DOM object using default parsing options
            HTMLDocument document = new HTMLDocument(inputPath);

            // Optional: output the outer HTML to verify loading
            string outerHtml = document.DocumentElement.OuterHTML;
            Console.WriteLine("Loaded HTML Document:");
            Console.WriteLine(outerHtml);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}