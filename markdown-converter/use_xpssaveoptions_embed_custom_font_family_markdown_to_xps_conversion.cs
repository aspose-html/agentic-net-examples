// Use XpsSaveOptions to embed a custom font family during Markdown to XPS conversion.

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string sourcePath = "sample.md";
            string savePath = "output.xps";
            string fontFolder = "fonts";
            string fontFilePath = System.IO.Path.Combine(fontFolder, "custom.ttf");

            // Ensure font folder and dummy font file exist
            if (!System.IO.Directory.Exists(fontFolder))
                System.IO.Directory.CreateDirectory(fontFolder);
            if (!System.IO.File.Exists(fontFilePath))
                System.IO.File.WriteAllBytes(fontFilePath, new byte[0]);

            // Markdown content with custom font reference
            string markdownContent = @"<style>
@font-face {
    font-family: 'CustomFont';
    src: url('fonts/custom.ttf');
}
</style>

# Sample Heading

<p style='font-family: ""CustomFont"";'>This paragraph uses a custom embedded font.</p>";

            System.IO.File.WriteAllText(sourcePath, markdownContent);

            // Convert Markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // XPS save options
            Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();

            // Convert HTMLDocument to XPS
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}