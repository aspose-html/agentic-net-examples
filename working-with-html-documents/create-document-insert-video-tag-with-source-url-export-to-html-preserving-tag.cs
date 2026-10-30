// Create a document, insert a video tag with source URL, and export to HTML preserving the tag.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "video.html");

            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Video Example</title></head><body></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var video = (Aspose.Html.HTMLElement)document.CreateElement("video");
            video.SetAttribute("src", "https://www.w3schools.com/html/mov_bbb.mp4");
            video.SetAttribute("controls", "controls");

            document.Body.AppendChild(video);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}