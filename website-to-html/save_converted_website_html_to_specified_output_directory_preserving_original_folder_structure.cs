// Save the converted website HTML to a specified output directory preserving original folder structure.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input folder and sample HTML file
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            Directory.CreateDirectory(inputFolder);
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Prepare output folder for image conversion
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputImages");
            Directory.CreateDirectory(outputFolder);

            // Convert each HTML file to JPEG image
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Additional conversion with custom resolution
            string customOutputDir = Path.Combine(Directory.GetCurrentDirectory(), "CustomResolution");
            Directory.CreateDirectory(customOutputDir);
            string[] inputs = new string[] { sampleHtmlPath };
            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    string outputPath = Path.Combine(customOutputDir, "custom_res.jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Convert to MHTML
            string mhtmlOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.mhtml");
            Aspose.Html.Saving.MHTMLSaveOptions mhtmlOptions = new Aspose.Html.Saving.MHTMLSaveOptions();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sampleHtmlPath))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, mhtmlOptions, mhtmlOutputPath);
            }

            // Convert to XPS
            string xpsOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.xps");
            Aspose.Html.Saving.XpsSaveOptions xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sampleHtmlPath))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(document, xpsOptions, xpsOutputPath);
            }

            // Convert Markdown to HTML
            string markdownPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.md");
            File.WriteAllText(markdownPath, "# Markdown Title\n\nThis is a **markdown** sample.");
            string markdownHtmlOutput = Path.Combine(Directory.GetCurrentDirectory(), "markdown_output.html");
            Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, markdownHtmlOutput);

            Console.WriteLine("Conversions completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}