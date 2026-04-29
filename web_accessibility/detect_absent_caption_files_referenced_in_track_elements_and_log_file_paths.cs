// Detect absent caption files referenced by <track> elements and log their file paths.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string logPath = "missing_captions.log";

            HTMLDocument doc = new HTMLDocument(htmlPath);
            HTMLCollection tracks = doc.GetElementsByTagName("track");

            foreach (Element track in tracks)
            {
                string src = track.GetAttribute("src");
                if (!string.IsNullOrEmpty(src) && !File.Exists(src))
                {
                    File.AppendAllText(logPath, src + Environment.NewLine);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}