// Create an HTML document from an MHTML source, modify its title, and save as HTML.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.mht";
            string outputPath = "output.html";

            using (HTMLDocument document = new HTMLDocument(sourcePath))
            {
                document.Title = "New Title";
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}