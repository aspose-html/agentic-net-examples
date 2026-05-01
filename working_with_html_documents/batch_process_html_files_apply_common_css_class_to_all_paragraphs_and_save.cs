// Batch process a list of HTML files, apply a common CSS class to all paragraphs, and save.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Folder containing source HTML files
            string inputFolder = @"C:\InputHtml";
            // Folder where modified HTML files will be saved
            string outputFolder = @"C:\OutputHtml";

            // Ensure the output directory exists
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Process each HTML file in the input folder
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Retrieve all <p> elements
                var paragraphs = document.GetElementsByTagName("p");

                // Apply the common CSS class to each paragraph
                foreach (Aspose.Html.HTMLElement paragraph in paragraphs)
                {
                    paragraph.SetAttribute("class", "common-paragraph");
                }

                // Determine the output file path
                string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));

                // Save the modified document
                document.Save(outputPath);

                // Release resources
                document.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}