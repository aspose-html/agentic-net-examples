// Batch convert a set of HTML files to XPS, applying a uniform 0.4‑inch left margin to each file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputXps";

            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                System.IO.File.WriteAllText(samplePath, "<html><body><h1>Hello World</h1></body></html>");
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                    options.BackgroundColor = System.Drawing.Color.White;
                    options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                        new Aspose.Html.Drawing.Size(
                            Aspose.Html.Drawing.Length.FromInches(8.5),
                            Aspose.Html.Drawing.Length.FromInches(11)),
                        new Aspose.Html.Drawing.Margin(
                            Aspose.Html.Drawing.Length.FromInches(0),      // top
                            Aspose.Html.Drawing.Length.FromInches(0.4),    // left
                            Aspose.Html.Drawing.Length.FromInches(0),      // right
                            Aspose.Html.Drawing.Length.FromInches(0)       // bottom
                        )
                    );

                    string outputPath = System.IO.Path.Combine(
                        outputFolder,
                        System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".xps"
                    );

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