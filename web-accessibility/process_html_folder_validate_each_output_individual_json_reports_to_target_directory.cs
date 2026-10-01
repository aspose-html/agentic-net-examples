// Process a folder of HTML files, validate each, and output individual JSON reports to a target directory.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input and output folders
            string inputFolder = Path.Combine(Directory.GetCurrentDirectory(), "InputHtml");
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "OutputImages");
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string sampleHtmlPath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(sampleHtmlPath))
            {
                File.WriteAllText(sampleHtmlPath, "<html><body><h1>Hello Aspose</h1></body></html>");
            }

            // Convert each HTML file to JPEG
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Additional conversion with resolution settings
            string resolutionOutputDir = Path.Combine(Directory.GetCurrentDirectory(), "ResolutionOutput");
            Directory.CreateDirectory(resolutionOutputDir);
            string[] inputs = new string[] { sampleHtmlPath, sampleHtmlPath };
            for (int i = 0; i < inputs.Length; i++)
            {
                string inputPath = inputs[i];
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    options.HorizontalResolution = 300;
                    options.VerticalResolution = 300;
                    string outputPath = Path.Combine(resolutionOutputDir, $"output_{i}.jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            // Template conversion example
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "data.json");
            if (!File.Exists(jsonPath))
            {
                File.WriteAllText(jsonPath, "{\"title\":\"Hello from template\"}");
            }

            string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "template.html");
            if (!File.Exists(templatePath))
            {
                File.WriteAllText(templatePath, "<html><body><h1>{{title}}</h1></body></html>");
            }

            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();
            using (Aspose.Html.HTMLDocument resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions))
            {
                string templateOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "template_output.html");
                resultDoc.Save(templateOutputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}