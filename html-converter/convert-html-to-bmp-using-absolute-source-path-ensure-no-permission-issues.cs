// Convert HTML to BMP using an absolute source path and ensure the file is accessed without permission issues.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = System.IO.Path.GetFullPath("sample.html");
            string outputPath = System.IO.Path.GetFullPath("output.bmp");

            if (!System.IO.File.Exists(inputPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(inputPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("HTML converted to BMP successfully. Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}