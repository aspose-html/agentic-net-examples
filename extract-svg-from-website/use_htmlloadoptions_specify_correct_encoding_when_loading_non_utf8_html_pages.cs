// Use HtmlLoadOptions to specify the correct encoding when loading non-UTF-8 HTML pages.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(sourcePath))
            {
                string sampleContent = "<html><body><p>Sample text with special char: €</p></body></html>";
                File.WriteAllText(sourcePath, sampleContent, Encoding.GetEncoding("windows-1252"));
            }

            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("windows-1252"));
            var document = new Aspose.Html.HTMLDocument(htmlContent, sourcePath);
            document.Save(outputPath);

            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}