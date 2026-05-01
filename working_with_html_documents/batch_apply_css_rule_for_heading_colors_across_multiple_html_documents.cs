// Batch apply a common internal CSS rule for heading colors across multiple HTML documents.

using System;
using System.Linq;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string[] inputFiles = { "input1.html", "input2.html" };
            string[] outputFiles = { "output1.html", "output2.html" };

            for (int i = 0; i < inputFiles.Length; i++)
            {
                string documentPath = inputFiles[i];
                HTMLDocument document = new HTMLDocument(documentPath);

                Element style = document.CreateElement("style");
                style.TextContent = "h1 { color: darkred; }";

                Element head = document.GetElementsByTagName("head").First();
                head.AppendChild(style);

                document.Save(outputFiles[i]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}