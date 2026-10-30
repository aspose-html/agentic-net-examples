// Replace target="_blank" attributes with rel="noopener noreferrer" to mitigate security risks in the document.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleContent = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <a href=""https://example.com"" target=""_blank"">Example Link</a>
    <a href=""https://example.org"">No Target Link</a>
</body>
</html>";
                System.IO.File.WriteAllText(inputPath, sampleContent);
            }

            // Load the HTML document from file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Select all elements with target="_blank"
            Aspose.Html.Collections.NodeList nodeList = document.QuerySelectorAll("[target=\"_blank\"]");

            // Replace target="_blank" with rel="noopener noreferrer"
            for (int i = 0; i < nodeList.Length; i++)
            {
                Aspose.Html.HTMLElement element = nodeList[i] as Aspose.Html.HTMLElement;
                if (element != null)
                {
                    element.SetAttribute("rel", "noopener noreferrer");
                }
            }

            // Save the modified document
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, saveOptions);

            Console.WriteLine("Document processed and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}