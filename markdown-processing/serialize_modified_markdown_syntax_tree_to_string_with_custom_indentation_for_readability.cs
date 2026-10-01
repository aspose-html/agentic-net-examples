// Serialize the modified MarkdownSyntaxTree to a string with custom indentation for readability.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<h1>Sample Heading</h1>\n<p>This is a paragraph.</p>";
            string baseUri = "";
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = System.IO.Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = System.IO.File.ReadAllText(tempPath);
            System.IO.File.Delete(tempPath);
            System.Console.WriteLine("Serialized Markdown:");
            System.Console.WriteLine(markdown);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}