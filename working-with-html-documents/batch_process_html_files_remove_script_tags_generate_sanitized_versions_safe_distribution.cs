// Batch process HTML files, remove all script tags, and generate sanitized versions for safe distribution.

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare folders
            string inputFolder = "InputHtml";
            string outputFolder = "OutputImages";
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (!Directory.GetFiles(inputFolder, "*.html").Any())
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><head><script>alert('test');</script></head><body><h1>Hello</h1></body></html>");
            }

            // 1. Convert each HTML file to JPEG image
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string imageOutputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, imageOutputPath);
                }
            }

            // 2. Remove all <script> elements from a specific HTML file and save
            string scriptInputPath = Path.Combine(inputFolder, "sample.html");
            string scriptOutputPath = Path.Combine(outputFolder, "sample_no_scripts.html");
            using (Aspose.Html.HTMLDocument docScripts = new Aspose.Html.HTMLDocument(scriptInputPath))
            {
                var scripts = docScripts.GetElementsByTagName("script");
                for (int i = scripts.Length - 1; i >= 0; i--)
                {
                    var script = scripts[i];
                    if (script.ParentNode != null)
                    {
                        script.ParentNode.RemoveChild(script);
                    }
                }
                docScripts.Save(scriptOutputPath);
            }

            // 3. Load HTML from a string with security configuration and output its outer HTML
            string htmlContent = "<html><body><h2>Temp Content</h2></body></html>";
            string tempFile = Path.Combine(Path.GetTempPath(), "temp.html");
            File.WriteAllText(tempFile, htmlContent);
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument tempDoc = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string output = tempDoc.DocumentElement != null ? tempDoc.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(output);
            }

            // 4. Convert the original HTML file to PDF
            string pdfOutputPath = Path.Combine(outputFolder, "sample.pdf");
            Aspose.Html.Configuration configPdf = new Aspose.Html.Configuration();
            configPdf.Security |= Aspose.Html.Sandbox.Scripts;
            using (Aspose.Html.HTMLDocument pdfDoc = new Aspose.Html.HTMLDocument(scriptInputPath, configPdf))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(pdfDoc, pdfOptions, pdfOutputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}