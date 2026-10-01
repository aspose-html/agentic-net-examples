// Create an HTML document from an MHTML source, modify its title, and save as HTML.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello Aspose HTML</h1></body></html>";
            string sourcePath = "sample.html";
            string outputPath = "output.mhtml";

            // Create a minimal HTML file to load
            File.WriteAllText(sourcePath, htmlContent, Encoding.UTF8);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath))
            {
                document.Save(outputPath, Aspose.Html.Saving.HTMLSaveFormat.MHTML);
            }

            Console.WriteLine($"MHTML file saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}