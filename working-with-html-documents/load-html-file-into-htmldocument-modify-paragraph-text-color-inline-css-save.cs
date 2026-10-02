// Load an HTML file into an HTMLDocument, modify paragraph text color using inline CSS, and save.

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                if (!System.IO.File.Exists(inputPath))
                {
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";
                    System.IO.File.WriteAllText(inputPath, sampleHtml);
                }

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)System.Linq.Enumerable.First(document.GetElementsByTagName("p"));
                paragraph.Style.Color = "red";
                document.Save(outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}