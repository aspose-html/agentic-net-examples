// Create a document, insert a video tag with source URL, and export to HTML preserving the tag.

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            System.IO.Directory.CreateDirectory(outputDir);
            string outputPath = System.IO.Path.Combine(outputDir, "video.html");

            string htmlContent = "<!DOCTYPE html><html><head><title>Video Example</title></head><body></body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Element video = document.CreateElement("video");
            video.SetAttribute("src", "https://example.com/video.mp4");
            video.SetAttribute("controls", "controls");
            document.Body.AppendChild(video);

            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}