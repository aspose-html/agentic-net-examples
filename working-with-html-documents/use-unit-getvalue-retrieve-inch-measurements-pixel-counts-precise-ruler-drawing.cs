// Use Unit.GetValue to retrieve inch measurements from pixel counts for precise ruler drawing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double pixelCount = 300.0;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            string htmlContent = $"<!DOCTYPE html><html><body><div style='width:{inches}in; height:0.2in; background:#000;'></div></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            document.Save("ruler.html");
            Console.WriteLine("Ruler HTML saved to ruler.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}