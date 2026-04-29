// Extract the file name from the URL and use it as the default local file name.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string url = "https://example.com/sample.html";
            HTMLDocument document = new HTMLDocument(url);
            Uri uri = new Uri(url);
            string fileName = Path.GetFileName(uri.LocalPath);
            if (string.IsNullOrEmpty(fileName))
                fileName = "output.html";
            document.Save(fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}