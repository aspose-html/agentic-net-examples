// Implement a command‑line argument parser that maps short flags to output formats for the conversion utility.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: <inputPath> <outputFlag> <outputPath>");
                return;
            }

            string inputPath = args[0];
            string flag = args[1];
            string outputPath = args[2];

            switch (flag)
            {
                case "-h":
                    // Convert Markdown to HTML
                    string sourcePath = inputPath;
                    string savePath = outputPath;
                    Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, savePath);
                    break;

                case "-m":
                    // Convert HTML to Markdown
                    string htmlPath = inputPath;
                    string mdSavePath = outputPath;
                    Aspose.Html.Saving.MarkdownSaveOptions mdOptions = new Aspose.Html.Saving.MarkdownSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, mdOptions, mdSavePath);
                    break;

                case "-g":
                    // Convert Markdown to GIF image
                    string mdSource = inputPath;
                    string gifPath = outputPath;
                    Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(mdSource);
                    Aspose.Html.Saving.ImageSaveOptions imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertHTML(document, imgOptions, gifPath);
                    break;

                case "-p":
                    // Convert HTML to PDF
                    string htmlSrc = inputPath;
                    string pdfPath = outputPath;
                    Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertHTML(htmlSrc, pdfOptions, pdfPath);
                    break;

                default:
                    Console.WriteLine("Unsupported flag.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}