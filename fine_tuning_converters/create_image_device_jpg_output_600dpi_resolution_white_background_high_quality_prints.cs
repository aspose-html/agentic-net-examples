// Create an ImageDevice for JPG output with 600 DPI resolution and white background for high‑quality prints.

using System;
using Aspose.Html.Rendering.Image;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 600;
            options.VerticalResolution = 600;
            options.BackgroundColor = Color.White;
            ImageDevice device = new ImageDevice(options, "output.jpg");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}