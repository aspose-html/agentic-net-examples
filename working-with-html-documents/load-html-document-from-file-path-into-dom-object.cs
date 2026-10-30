// Load an HTML document from a file path into a DOM object.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";

            if (!File.Exists(inputPath))
            {
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, sampleContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            string htmlContent = document.DocumentElement.OuterHTML;
            Console.WriteLine(htmlContent);
            document.Dispose();
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}