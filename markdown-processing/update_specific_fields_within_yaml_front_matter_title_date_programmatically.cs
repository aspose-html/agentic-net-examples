// Update specific fields within the YAML front‑matter, such as title or date, programmatically.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head>
    <title>Old Title</title>
    <meta name=""date"" content=""2020-01-01"">
</head>
<body>
    <p>Hello, World!</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Update the title
            document.Title = "New Title";

            // Update the date meta tag or create it if missing
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLElement;
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            Aspose.Html.HTMLElement dateMeta = document.QuerySelector("meta[name='date']") as Aspose.Html.HTMLElement;
            if (dateMeta == null)
            {
                dateMeta = document.CreateElement("meta") as Aspose.Html.HTMLElement;
                dateMeta.SetAttribute("name", "date");
                head.AppendChild(dateMeta);
            }
            dateMeta.SetAttribute("content", "2023-10-01");

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}