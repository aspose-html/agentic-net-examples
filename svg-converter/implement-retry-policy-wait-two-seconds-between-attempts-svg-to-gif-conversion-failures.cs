// Implement a retry policy that waits two seconds between attempts for SVG to GIF conversion failures.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";
            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            string svgFileName = "sample.svg";
            string svgPath = System.IO.Path.Combine(inputFolder, svgFileName);
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
            System.IO.File.WriteAllText(svgPath, svgContent);

            string outputPath = System.IO.Path.Combine(outputFolder, "sample.gif");

            int maxAttempts = 3;
            bool success = false;

            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(svgPath);
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                    Console.WriteLine("Conversion succeeded on attempt " + attempt);
                    success = true;
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Attempt " + attempt + " failed: " + ex.Message);
                    if (attempt < maxAttempts)
                    {
                        System.Threading.Thread.Sleep(2000);
                    }
                }
            }

            if (!success)
            {
                Console.WriteLine("All conversion attempts failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}