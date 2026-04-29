// Embed a .vtt caption file into the HTML document and reference it via a newly created <track> element.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            var doc = new HTMLDocument("input.html");
            var body = doc.Body;
            var track = doc.CreateElement("track");
            track.SetAttribute("kind", "captions");
            track.SetAttribute("src", "captions.vtt");
            track.SetAttribute("srclang", "en");
            track.SetAttribute("label", "English");
            body.AppendChild(track);
            doc.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}