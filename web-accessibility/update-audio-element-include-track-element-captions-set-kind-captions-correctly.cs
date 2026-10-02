// Update an audio element to include a <track> element for captions and set kind="captions" correctly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><audio id='myAudio' controls src='sample.mp3'></audio></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.Collections.HTMLCollection audios = document.GetElementsByTagName("audio");
            foreach (Aspose.Html.Dom.Element audio in audios)
            {
                Aspose.Html.Dom.Element track = document.CreateElement("track");
                track.SetAttribute("src", "captions.vtt");
                track.SetAttribute("kind", "captions");
                track.SetAttribute("srclang", "en");
                track.SetAttribute("label", "English");
                audio.AppendChild(track);
            }
            string outputPath = "output.html";
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}