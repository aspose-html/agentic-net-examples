// Batch convert a set of HTML files to XPS, applying a uniform 0.4‑inch left margin to each file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputXps";

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Create sample input if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                Directory.CreateDirectory(inputFolder);
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><h1>Sample HTML</h1><p>This is a test.</p></body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    options.BackgroundColor = System.Drawing.Color.White;

                    Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.5),
                        Aspose.Html.Drawing.Length.FromInches(11));

                    Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                        Aspose.Html.Drawing.Length.FromInches(0.4), // left margin
                        Aspose.Html.Drawing.Length.FromInches(0),   // top margin
                        Aspose.Html.Drawing.Length.FromInches(0),   // right margin
                        Aspose.Html.Drawing.Length.FromInches(0));  // bottom margin

                    Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
                    options.PageSetup.AnyPage = page;

                    string outputPath = Path.Combine(outputFolder,
                        Path.GetFileNameWithoutExtension(htmlPath) + ".xps");

                    Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}