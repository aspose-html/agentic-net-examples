// Implement try‑catch error handling when loading an HTML file that may not exist.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.html";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
                string html = document.DocumentElement.OuterHTML;
                System.Console.WriteLine(html);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error loading HTML file: " + ex.Message);
            }
        }
    }
}