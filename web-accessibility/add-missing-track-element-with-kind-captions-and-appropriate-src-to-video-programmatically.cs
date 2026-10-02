// Add a missing <track> element with kind="captions" and appropriate src attribute to a video element programmatically.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare sample HTML content with a video element lacking a track
            string htmlContent = "<!DOCTYPE html><html><body><video id='myVideo' src='movie.mp4'></video></body></html>";

            // Load the HTML document from the string (use two‑argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all <video> elements
            Aspose.Html.Collections.HTMLCollection videos = document.GetElementsByTagName("video");

            for (int i = 0; i < videos.Length; i++)
            {
                Aspose.Html.Dom.Element videoElement = videos[i] as Aspose.Html.Dom.Element;
                if (videoElement == null)
                    continue;

                // Create a <track> element for captions
                Aspose.Html.Dom.Element trackElement = document.CreateElement("track");
                trackElement.SetAttribute("kind", "captions");
                trackElement.SetAttribute("src", "captions.vtt");
                trackElement.SetAttribute("srclang", "en");
                trackElement.SetAttribute("label", "English");

                // Append the track to the video element
                videoElement.AppendChild(trackElement);
            }

            // Prepare output directory and file path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "result.html");

            // Save the modified document
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, saveOptions);

            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}