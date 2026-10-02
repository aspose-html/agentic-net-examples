// Split the document into chapters based on level‑2 headings and save each as a separate file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputFolder = "output";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<h1>Document Title</h1>
<h2>Chapter 1</h2>
<p>Content of chapter 1.</p>
<h2>Chapter 2</h2>
<p>Content of chapter 2.</p>
<h2>Chapter 3</h2>
<p>Content of chapter 3.</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the source document
            var sourceDoc = new Aspose.Html.HTMLDocument(inputPath);
            var headings = sourceDoc.QuerySelectorAll("h2");

            int chapterIndex = 0;
            foreach (Aspose.Html.HTMLElement heading in headings)
            {
                var newDoc = new Aspose.Html.HTMLDocument();
                var newBody = newDoc.Body;

                // Clone the heading and add to new document
                var clonedHeading = (Aspose.Html.HTMLElement)heading.CloneNode(true);
                newBody.AppendChild(clonedHeading);

                // Append following siblings until the next h2
                var sibling = heading.NextSibling;
                while (sibling != null)
                {
                    // Stop if the sibling is another level‑2 heading
                    if (sibling is Aspose.Html.HTMLHeadingElement nextHeading &&
                        string.Equals(nextHeading.TagName, "h2", StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }

                    var clonedSibling = sibling.CloneNode(true);
                    if (clonedSibling is Aspose.Html.HTMLElement element)
                    {
                        newBody.AppendChild(element);
                    }

                    sibling = sibling.NextSibling;
                }

                string outputPath = Path.Combine(outputFolder, $"chapter_{++chapterIndex}.html");
                newDoc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}