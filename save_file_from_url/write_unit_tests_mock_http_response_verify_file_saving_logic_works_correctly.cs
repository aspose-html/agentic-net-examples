// Write unit tests that mock the HTTP response to verify the file saving logic works correctly.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello World</h1></body></html>";
            string baseUri = "http://example.com/";
            string outputPath = Path.Combine(Path.GetTempPath(), "output.html");

            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(html, baseUri);
            doc.Save(outputPath);

            if (!File.Exists(outputPath))
                throw new Exception("Output file was not created.");

            if (new FileInfo(outputPath).Length == 0)
                throw new Exception("Output file is empty.");

            Console.WriteLine("File saving verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}