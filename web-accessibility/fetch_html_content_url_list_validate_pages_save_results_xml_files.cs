// Fetch HTML content from a list of URLs, validate each page, and save results as XML files.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare URLs to validate
            System.Collections.Generic.List<string> urls = new System.Collections.Generic.List<string>
            {
                "https://example.com",
                "https://example.org"
            };

            // Ensure output directory exists
            System.IO.Directory.CreateDirectory("output");

            // Initialize accessibility validator
            Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
            Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

            int index = 1;
            foreach (string url in urls)
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
                {
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    string outputPath = System.IO.Path.Combine("output", $"validation_result_{index}.xml");
                    System.IO.File.WriteAllText(outputPath, validationResult.ToString());
                }
                index++;
            }

            // Create a minimal sample HTML file with a table if it does not exist
            string sampleFilePath = "sample.html";
            if (!System.IO.File.Exists(sampleFilePath))
            {
                string sampleContent = @"<html><body><table><tr><td>Cell</td></tr></table></body></html>";
                System.IO.File.WriteAllText(sampleFilePath, sampleContent);
            }

            // Load the sample document and process tables
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sampleFilePath))
            {
                Aspose.Html.Collections.HTMLCollection tables = document.GetElementsByTagName("table");
                if (tables != null && tables.Length > 0)
                {
                    int i = 0;
                    foreach (Aspose.Html.Dom.Element table in tables)
                    {
                        string newFileName = $"checked-web-table{i}.html";
                        string tablePath = System.IO.Path.Combine("output", newFileName);
                        // Write the outer HTML of the table to a file
                        System.IO.File.WriteAllText(tablePath, table.ToString());
                        i++;
                    }
                }
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}