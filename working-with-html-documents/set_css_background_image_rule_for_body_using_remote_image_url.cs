// Set a CSS background-image rule for the body element using a remote image URL.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body></body></html>");
            }

            HTMLDocument document = new HTMLDocument(inputPath);
            Element bodyElement = document.QuerySelector("body");
            if (bodyElement != null)
            {
                bodyElement.SetAttribute("style", "background-image: url('https://example.com/image.jpg');");
            }

            document.Save(outputPath);
            Console.WriteLine("Background image applied and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}