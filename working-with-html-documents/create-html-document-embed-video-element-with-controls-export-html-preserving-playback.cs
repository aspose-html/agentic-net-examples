// Create an HTML document, embed a video element with controls, and export to HTML preserving playback.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Video Example</title></head><body><video controls width=\"640\" height=\"360\"><source src=\"sample.mp4\" type=\"video/mp4\">Your browser does not support the video tag.</video></body></html>";

            string videoPath = "sample.mp4";
            if (!System.IO.File.Exists(videoPath))
            {
                System.IO.File.WriteAllBytes(videoPath, new byte[0]);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            string outputPath = "video.html";
            document.Save(outputPath);

            System.Console.WriteLine($"HTML saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}