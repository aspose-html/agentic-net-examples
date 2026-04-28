// Add a missing charset meta tag based on detected file encoding to improve compatibility.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";

            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.UTF8);

            if (!htmlContent.Contains("<meta charset", StringComparison.OrdinalIgnoreCase))
            {
                int headIndex = htmlContent.IndexOf("<head>", StringComparison.OrdinalIgnoreCase);
                if (headIndex != -1)
                {
                    int insertPos = headIndex + "<head>".Length;
                    string metaTag = "<meta charset=\"utf-8\">";
                    htmlContent = htmlContent.Insert(insertPos, metaTag);
                }
            }

            HTMLDocument document = new HTMLDocument(htmlContent, ".");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}