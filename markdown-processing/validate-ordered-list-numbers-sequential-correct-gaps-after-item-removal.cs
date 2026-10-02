// Validate that ordered list numbers are sequential and correct any gaps after item removal.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string inputPath = "sample.html";
            string outputPath = "corrected.html";

            // Create a sample HTML with an ordered list that has gaps
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<ol>
<li>Item 1</li>
<li value=""2"">Item 2</li>
<li value=""4"">Item 4 (gap)</li>
<li>Item 5</li>
</ol>
</body>
</html>";
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document from the file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all ordered list elements
            Aspose.Html.Collections.HTMLCollection olCollection = document.GetElementsByTagName("ol");
            for (int i = 0; i < olCollection.Length; i++)
            {
                Aspose.Html.Dom.Element olElement = (Aspose.Html.Dom.Element)olCollection[i];

                // Get all list item elements within this ordered list
                Aspose.Html.Collections.HTMLCollection liCollection = olElement.GetElementsByTagName("li");
                for (int j = 0; j < liCollection.Length; j++)
                {
                    Aspose.Html.Dom.Element liElement = (Aspose.Html.Dom.Element)liCollection[j];
                    // Set the correct sequential value
                    liElement.SetAttribute("value", (j + 1).ToString());
                }
            }

            // Save the corrected HTML document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}