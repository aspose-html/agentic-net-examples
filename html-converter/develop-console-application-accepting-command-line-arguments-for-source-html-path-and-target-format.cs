// Develop a console application that accepts command‑line arguments for source HTML path and target format.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = args.Length > 0 ? args[0] : "sample.html";
            string targetFormat = args.Length > 1 ? args[1].ToLowerInvariant() : "pdf";

            if (!System.IO.File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(sourcePath, sampleHtml);
            }

            string outputPath;

            if (targetFormat == "pdf")
            {
                var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                outputPath = System.IO.Path.ChangeExtension(sourcePath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertHTML(new Aspose.Html.Url(sourcePath), null, pdfOptions, outputPath);
            }
            else if (targetFormat == "png")
            {
                var imgOptions = new Aspose.Html.Saving.ImageSaveOptions();
                imgOptions.Format = Aspose.Html.Rendering.Image.ImageFormat.Png;
                outputPath = System.IO.Path.ChangeExtension(sourcePath, ".png");
                Aspose.Html.Converters.Converter.ConvertHTML(new Aspose.Html.Url(sourcePath), null, imgOptions, outputPath);
            }
            else if (targetFormat == "jpeg" || targetFormat == "jpg")
            {
                var imgOptions = new Aspose.Html.Saving.ImageSaveOptions();
                imgOptions.Format = Aspose.Html.Rendering.Image.ImageFormat.Jpeg;
                outputPath = System.IO.Path.ChangeExtension(sourcePath, ".jpg");
                Aspose.Html.Converters.Converter.ConvertHTML(new Aspose.Html.Url(sourcePath), null, imgOptions, outputPath);
            }
            else if (targetFormat == "markdown")
            {
                var mdOptions = new Aspose.Html.Saving.MarkdownSaveOptions();
                outputPath = System.IO.Path.ChangeExtension(sourcePath, ".md");
                Aspose.Html.Converters.Converter.ConvertHTML(new Aspose.Html.Url(sourcePath), null, mdOptions, outputPath);
            }
            else if (targetFormat == "mhtml")
            {
                var mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
                outputPath = System.IO.Path.ChangeExtension(sourcePath, ".mhtml");
                Aspose.Html.Converters.Converter.ConvertHTML(new Aspose.Html.Url(sourcePath), null, mhtmlOptions, outputPath);
            }
            else
            {
                throw new ArgumentException("Unsupported target format: " + targetFormat);
            }

            Console.WriteLine("Conversion completed. Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}