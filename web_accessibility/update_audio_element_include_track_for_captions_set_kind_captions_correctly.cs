// Update an audio element to include a <track> element for captions and set kind="captions" correctly.

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

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Retrieve all <audio> elements
            HTMLCollection audios = document.GetElementsByTagName("audio");
            foreach (Element audio in audios)
            {
                // Create a <track> element for captions
                Element track = document.CreateElement("track");
                track.SetAttribute("src", "captions.vtt");
                track.SetAttribute("kind", "captions");
                track.SetAttribute("srclang", "en");
                track.SetAttribute("label", "English captions");

                // Append the <track> to the <audio> element
                audio.AppendChild(track);
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}