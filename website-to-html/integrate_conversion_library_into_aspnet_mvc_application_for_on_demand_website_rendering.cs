// Integrate the conversion library into an ASP.NET MVC application for on‑demand website rendering.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample markdown file and convert it to HTML
            string markdownPath = "sample.md";
            File.WriteAllText(markdownPath, "# Sample Markdown\nThis is a test markdown file.");
            string markdownOutput = "sample.html";
            Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, markdownOutput);
            Console.WriteLine($"Markdown converted to HTML: {markdownOutput}");

            // Create a minimal MHTML file (simple HTML saved with .mhtml extension)
            string mhtmlPath = "sample.mhtml";
            File.WriteAllText(mhtmlPath, "<html><body><h1>MHTML Sample</h1><p>Test content.</p></body></html>");
            
            // Convert MHTML to DOCX using helper method
            using (FileStream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                byte[] docxBytes = ConvertMhtmlToDocxBytes(mhtmlStream);
                string docxOutput = "sample.docx";
                File.WriteAllBytes(docxOutput, docxBytes);
                Console.WriteLine($"MHTML converted to DOCX: {docxOutput}");
            }

            // Convert MHTML to BMP image
            string imageOutput = "sample.bmp";
            using (FileStream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                var imgOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
                imgOptions.UseAntialiasing = true;
                imgOptions.HorizontalResolution = 96;
                imgOptions.VerticalResolution = 96;
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, imgOptions, imageOutput);
                Console.WriteLine($"MHTML converted to image: {imageOutput}");
            }

            // Convert MHTML to XPS
            string xpsOutput = "sample.xps";
            using (FileStream mhtmlStream = File.OpenRead(mhtmlPath))
            {
                var xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, xpsOptions, xpsOutput);
                Console.WriteLine($"MHTML converted to XPS: {xpsOutput}");
            }

            // Convert HTML file to XPS (demonstrating ConvertHTML overload)
            string htmlSource = markdownOutput; // using the HTML generated from markdown
            string htmlXpsOutput = "html_output.xps";
            var htmlXpsOptions = new Aspose.Html.Saving.XpsSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlSource, "", htmlXpsOptions, htmlXpsOutput);
            Console.WriteLine($"HTML converted to XPS: {htmlXpsOutput}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static byte[] ConvertMhtmlToDocxBytes(Stream inputStream)
    {
        string tempDocxPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".docx");
        var options = new Aspose.Html.Saving.DocSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputStream, options, tempDocxPath);
        byte[] result = File.ReadAllBytes(tempDocxPath);
        // Clean up temporary file
        try { File.Delete(tempDocxPath); } catch { }
        return result;
    }
}