// Create an HTML document, embed a video element with controls, and export to HTML preserving playback.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"><title>Video Example</title></head><body><video controls width=\"640\" height=\"360\"><source src=\"sample.mp4\" type=\"video/mp4\">Your browser does not support the video tag.</video></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            string outputPath = "video_example.html";
            document.Save(outputPath);
            System.Console.WriteLine("HTML document saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}