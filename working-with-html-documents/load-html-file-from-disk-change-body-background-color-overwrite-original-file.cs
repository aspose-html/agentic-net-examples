// Load an HTML file from disk, change body background color, and overwrite the original file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";

            // Create a minimal HTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath,
                    "<html><head><title>Sample</title></head><body><p>Hello, World!</p></body></html>");
            }

            // Load the HTML document from disk
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Access the <body> element and change its background color
            Aspose.Html.HTMLElement body = (Aspose.Html.HTMLElement)document.GetElementsByTagName("body")[0];
            body.Style.BackgroundColor = "lightblue";

            // Overwrite the original file with the modified document
            document.Save(inputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}