// Retrieve audio source URLs from audio tags and save them to a manifest file.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with audio tags
            string htmlContent = @"
                <html>
                    <body>
                        <audio src='audio1.mp3'></audio>
                        <audio src='audio2.ogg'></audio>
                        <audio></audio>
                    </body>
                </html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all audio elements
            Aspose.Html.Collections.HTMLCollection audioElements = document.GetElementsByTagName("audio");

            List<string> audioSources = new List<string>();

            for (int i = 0; i < audioElements.Length; i++)
            {
                Aspose.Html.Dom.Element audioElement = (Aspose.Html.Dom.Element)audioElements[i];
                string src = audioElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    audioSources.Add(src);
                }
            }

            // Save manifest file
            string manifestPath = "audio_manifest.txt";
            File.WriteAllLines(manifestPath, audioSources);

            Console.WriteLine($"Audio manifest saved to '{manifestPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}