// Update an audio element to include a <track> element for captions and set kind="captions" correctly.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
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
                string sampleHtml = "<!DOCTYPE html><html><body><audio controls src=\"audio.mp3\"></audio></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            HTMLDocument document = new HTMLDocument(inputPath);
            HTMLCollection audios = document.GetElementsByTagName("audio");

            if (audios.Length > 0)
            {
                Element audio = audios[0];
                Element track = document.CreateElement("track");
                track.SetAttribute("kind", "captions");
                track.SetAttribute("src", "captions.vtt");
                audio.AppendChild(track);
            }

            document.Save(outputPath);
            Console.WriteLine("Updated HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}