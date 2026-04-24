// Convert EPUB to PNG and define a transparent background using ImageSaveOptions.BackgroundColor set to transparent.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            using (Stream stream = File.OpenRead("input.epub"))
            {
                string outputPath = "output.png";
                ImageSaveOptions options = new ImageSaveOptions();
                options.BackgroundColor = Color.Transparent;
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}