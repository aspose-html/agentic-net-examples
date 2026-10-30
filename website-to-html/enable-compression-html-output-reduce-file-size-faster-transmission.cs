// Enable compression of the HTML output to reduce file size for faster transmission.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string inputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            System.IO.File.WriteAllText(inputPath, htmlContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();
                // If compression is supported, you could enable it:
                // options.Compression = Aspose.Html.Saving.Compression.GZip;

                string outputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "compressed.html");
                document.Save(outputPath, options);
                Console.WriteLine("Compressed HTML saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}