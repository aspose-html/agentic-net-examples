// Create a console application that reads a list of MHTML paths from a text file and converts each to PNG.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string listFilePath = "mhtml_list.txt";
            if (!File.Exists(listFilePath))
                throw new FileNotFoundException("The list file was not found.", listFilePath);

            string[] mhtmlPaths = File.ReadAllLines(listFilePath);
            foreach (string mhtmlPathRaw in mhtmlPaths)
            {
                string mhtmlPath = mhtmlPathRaw.Trim();
                if (string.IsNullOrEmpty(mhtmlPath))
                    continue;

                string outputPath = Path.ChangeExtension(mhtmlPath, ".png");

                using (Stream stream = File.OpenRead(mhtmlPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Png);
                    Converter.ConvertMHTML(stream, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}