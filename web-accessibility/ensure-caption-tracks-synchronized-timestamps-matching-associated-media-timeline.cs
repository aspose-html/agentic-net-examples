// Ensure caption tracks contain synchronized timestamps matching the associated media timeline.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Output");
            System.IO.Directory.CreateDirectory(outputDir);

            // Create VTT file with synchronized timestamps
            string vttContent = "WEBVTT\n\n" +
                                "00:00:00.000 --> 00:00:05.000\n" +
                                "Hello, world!\n\n" +
                                "00:00:05.000 --> 00:00:10.000\n" +
                                "This is a caption.\n";
            string vttPath = System.IO.Path.Combine(outputDir, "captions.vtt");
            System.IO.File.WriteAllText(vttPath, vttContent);

            // Create HTML document
            string htmlTemplate = "<!DOCTYPE html><html><head><title>Video with Captions</title></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlTemplate, "about:blank");

            // Create video element
            Aspose.Html.Dom.Element video = document.CreateElement("video");
            video.SetAttribute("width", "640");
            video.SetAttribute("height", "360");
            video.SetAttribute("controls", "controls");
            video.SetAttribute("src", "https://example.com/sample.mp4");

            // Create track element for captions
            Aspose.Html.Dom.Element track = document.CreateElement("track");
            track.SetAttribute("kind", "captions");
            track.SetAttribute("src", "captions.vtt");
            track.SetAttribute("srclang", "en");
            track.SetAttribute("label", "English");
            track.SetAttribute("default", "default");

            // Assemble DOM
            video.AppendChild(track);
            document.Body.AppendChild(video);

            // Save HTML file
            string htmlPath = System.IO.Path.Combine(outputDir, "index.html");
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(htmlPath, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}