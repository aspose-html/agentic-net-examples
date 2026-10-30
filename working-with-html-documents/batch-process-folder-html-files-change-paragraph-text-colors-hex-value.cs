// Batch process a folder of HTML files to change all paragraph text colors to a specified hex value.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output folders
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a minimal sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>");
            }

            // Process each HTML file in the input folder
            foreach (string filePath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                HTMLDocument document = new HTMLDocument(filePath);

                // Select all paragraph elements
                Aspose.Html.Collections.NodeList paragraphs = document.QuerySelectorAll("p");

                // Change text color of each paragraph
                foreach (HTMLElement paragraph in paragraphs)
                {
                    paragraph.Style.Color = "#FF5733"; // Desired hex color
                }

                // Save the modified document to the output folder
                string outputPath = Path.Combine(outputFolder, Path.GetFileName(filePath));
                document.Save(outputPath);
            }

            Console.WriteLine("Batch processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}