// Load an HTML document from a file path into a DOM object.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                string htmlContent = document.DocumentElement.OuterHTML;
                Console.WriteLine(htmlContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}