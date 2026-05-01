// Set character encoding to ISO-8859-1, load an HTML string, and save the document as HTML.

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
            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}