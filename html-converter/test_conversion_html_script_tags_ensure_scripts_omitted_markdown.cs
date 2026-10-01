// Test conversion of HTML containing script tags to ensure scripts are omitted from the resulting Markdown.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<html><head><script>var a = 1;</script></head><body><h1>Hello</h1><p>World</p></body></html>";
                string baseUri = "http://example.com/";
                Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
                string tempPath = System.IO.Path.GetTempFileName();
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
                string markdown = System.IO.File.ReadAllText(tempPath);
                System.IO.File.Delete(tempPath);
                System.Console.WriteLine("Generated Markdown:");
                System.Console.WriteLine(markdown);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}