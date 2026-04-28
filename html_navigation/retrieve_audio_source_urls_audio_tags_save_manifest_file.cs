// Retrieve audio source URLs from audio tags and save them to a manifest file.

using System;
using System.Collections.Generic;
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
            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("input.html");

            // Get all <audio> elements
            Aspose.Html.Collections.HTMLCollection audioElements = document.GetElementsByTagName("audio");

            List<string> audioUrls = new List<string>();

            // Iterate through the collection and extract src attributes
            for (int i = 0; i < audioElements.Length; i++)
            {
                Aspose.Html.Dom.Element audioElement = (Aspose.Html.Dom.Element)audioElements[i];
                string src = audioElement.GetAttribute("src");
                if (!string.IsNullOrEmpty(src))
                {
                    Aspose.Html.Url url = new Aspose.Html.Url(src, document.BaseURI);
                    audioUrls.Add(url.ToString());
                }
            }

            // Save the extracted URLs to a manifest file
            File.WriteAllLines("audio_manifest.txt", audioUrls);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}