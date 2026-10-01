// Create a document, insert a video tag with source URL, and export to HTML preserving the tag.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "http://example.com/");

            Aspose.Html.Dom.Element video = document.CreateElement("video");
            video.SetAttribute("src", "https://example.com/video.mp4");
            video.SetAttribute("controls", "controls");

            document.Body.AppendChild(video);

            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}