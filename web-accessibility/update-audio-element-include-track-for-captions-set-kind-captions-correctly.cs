// Update an audio element to include a <track> element for captions and set kind="captions" correctly.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><audio id='myAudio' controls src='audio.mp3'></audio></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.Collections.HTMLCollection audios = document.GetElementsByTagName("audio");

            for (int i = 0; i < audios.Length; i++)
            {
                Aspose.Html.Dom.Element audio = audios[i] as Aspose.Html.Dom.Element;
                if (audio != null)
                {
                    Aspose.Html.Dom.Element track = document.CreateElement("track");
                    track.SetAttribute("kind", "captions");
                    track.SetAttribute("src", "captions.vtt");
                    track.SetAttribute("srclang", "en");
                    track.SetAttribute("label", "English");
                    audio.AppendChild(track);
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Modified HTML saved to {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}