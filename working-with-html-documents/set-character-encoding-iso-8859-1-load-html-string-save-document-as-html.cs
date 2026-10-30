// Set character encoding to ISO-8859-1, load an HTML string, and save the document as HTML.

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
                string sampleContent = "<!DOCTYPE html><html><head><meta charset=\"ISO-8859-1\"><title>Sample</title></head><body><p>Ol\u00E1, mundo!</p></body></html>";
                File.WriteAllText(sourcePath, sampleContent, Encoding.GetEncoding("ISO-8859-1"));
            }

            string htmlContent = File.ReadAllText(sourcePath, Encoding.GetEncoding("ISO-8859-1"));
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            document.Save(outputPath);
            Console.WriteLine("HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}