// Run the Converter class in a console utility to convert HTML files supplied via command‑line arguments.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath;
            string outputPath;

            if (args.Length >= 2)
            {
                sourcePath = args[0];
                outputPath = args[1];
            }
            else
            {
                string tempFolder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "AsposeHtmlSample");
                System.IO.Directory.CreateDirectory(tempFolder);
                sourcePath = System.IO.Path.Combine(tempFolder, "sample.html");
                System.IO.File.WriteAllText(sourcePath, "<html><body><h1>Hello Aspose HTML</h1></body></html>");
                outputPath = System.IO.Path.Combine(tempFolder, "output.jpg");
            }

            if (!System.IO.File.Exists(sourcePath))
                throw new System.IO.FileNotFoundException("Source HTML file not found.", sourcePath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, sourcePath, options, outputPath);

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}