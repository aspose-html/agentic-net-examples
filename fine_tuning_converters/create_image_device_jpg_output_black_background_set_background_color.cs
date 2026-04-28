// Create an ImageDevice for JPG output with a black background by setting RenderingOptions.BackgroundColor.

using System;
using System.Drawing;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            ImageRenderingOptions options = new ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.BackgroundColor = Color.Black;

            string outputPath = "output.jpg";
            ImageDevice device = new ImageDevice(options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}