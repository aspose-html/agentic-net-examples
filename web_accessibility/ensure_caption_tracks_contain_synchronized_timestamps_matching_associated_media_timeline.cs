// Ensure caption tracks contain synchronized timestamps matching the associated media timeline.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            HTMLDocument document = new HTMLDocument(inputPath);
            HTMLCollection tracks = document.GetElementsByTagName("track");

            for (int i = 0; i < tracks.Length; i++)
            {
                Element track = (Element)tracks[i];
                Node parent = track.ParentNode;
                if (parent is Element media && (media.TagName.Equals("video", StringComparison.OrdinalIgnoreCase) ||
                                                media.TagName.Equals("audio", StringComparison.OrdinalIgnoreCase)))
                {
                    string mediaSrc = media.GetAttribute("src");
                    if (!string.IsNullOrEmpty(mediaSrc))
                    {
                        string baseName = System.IO.Path.GetFileNameWithoutExtension(mediaSrc);
                        string vttPath = baseName + ".vtt";
                        track.SetAttribute("src", vttPath);
                    }
                }
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}