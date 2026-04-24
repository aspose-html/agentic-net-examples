// Convert HTML to GIF and set frame delay to 100ms for each frame using ImageSaveOptions if supported.

using System;
using System.IO;
using System.Reflection;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.gif";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Configure image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Attempt to set frame delay to 100ms if the API supports it
            PropertyInfo gifAnimProp = typeof(ImageSaveOptions).GetProperty("GifAnimationOptions");
            if (gifAnimProp != null && gifAnimProp.CanWrite)
            {
                // Try to create an instance of GifAnimationOptions via reflection
                Type gifAnimType = Type.GetType("Aspose.Html.Saving.GifAnimationOptions, Aspose.Html");
                if (gifAnimType != null)
                {
                    object gifAnimInstance = Activator.CreateInstance(gifAnimType);
                    PropertyInfo frameDelayProp = gifAnimType.GetProperty("FrameDelay");
                    if (frameDelayProp != null && frameDelayProp.CanWrite)
                    {
                        // Set frame delay to 100 milliseconds
                        frameDelayProp.SetValue(gifAnimInstance, 100);
                    }
                    // Assign the configured GifAnimationOptions back to ImageSaveOptions
                    gifAnimProp.SetValue(options, gifAnimInstance);
                }
            }

            // Convert HTML to GIF
            Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}