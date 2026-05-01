// Set a CSS background-image rule for the body element using a remote image URL.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

namespace BackgroundImageExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";
                string imageUrl = "https://example.com/background.jpg";

                HTMLDocument document = new HTMLDocument(inputPath);
                Element body = document.QuerySelector("body");
                if (body != null)
                {
                    body.SetAttribute("style", $"background-image: url('{imageUrl}');");
                }
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}