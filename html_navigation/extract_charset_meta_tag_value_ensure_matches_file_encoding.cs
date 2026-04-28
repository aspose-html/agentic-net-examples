// Extract the value of the charset meta tag and ensure it matches the file encoding.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";
            string encodingName = "utf-8";

            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.GetEncoding(encodingName));
            string baseUri = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(sourcePath));

            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            string charset = document.Charset;
            string fileEncoding = System.Text.Encoding.GetEncoding(encodingName).WebName;

            if (!string.Equals(charset, fileEncoding, StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"Charset meta tag '{charset}' does not match file encoding '{fileEncoding}'.");
            else
                Console.WriteLine($"Charset matches file encoding: {charset}");

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}