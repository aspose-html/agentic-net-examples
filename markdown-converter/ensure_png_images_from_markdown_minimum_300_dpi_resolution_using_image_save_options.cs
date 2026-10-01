// Ensure PNG images produced from Markdown have a minimum resolution of 300 DPI by setting ImageSaveOptions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string markdownPath = "sample.md";
            if (!System.IO.File.Exists(markdownPath))
            {
                System.IO.File.WriteAllText(markdownPath, "# Hello World\nThis is a sample markdown.");
            }

            var document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            string outputPath = "output.png";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}