// Load an HTML file, compress its whitespace, and write the minified version to disk.

namespace AsposeHtmlMinifyExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.min.html";

                if (!System.IO.File.Exists(inputPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1>   <p>   This is a   sample.</p></body></html>";
                    System.IO.File.WriteAllText(inputPath, sampleHtml);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

                Aspose.Html.Saving.HTMLSaveOptions options = new Aspose.Html.Saving.HTMLSaveOptions();

                document.Save(outputPath, options);

                System.Console.WriteLine("HTML saved to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}