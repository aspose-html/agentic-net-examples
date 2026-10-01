// Generate an HTML preview of the Markdown content using the built‑in renderer for visual verification.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "preview.html";

            // Create a sample markdown file
            System.IO.File.WriteAllText(sourcePath, "# Sample Title\n\nThis is a **markdown** sample.");

            // Convert markdown to HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Save the HTML preview
            document.Save(savePath);

            // Output the generated HTML
            System.Console.WriteLine(document.DocumentElement.OuterHTML);
            System.Console.WriteLine("Conversion completed. HTML saved at " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}