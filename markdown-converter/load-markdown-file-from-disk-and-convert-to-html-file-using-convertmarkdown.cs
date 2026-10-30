// Load a Markdown file from disk and convert it to an HTML file using ConvertMarkdown.

public class Program
{
    public static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string savePath = "output.html";

            if (!System.IO.File.Exists(sourcePath))
            {
                string sampleContent = "# Hello World\r\nThis is a sample markdown file.";
                System.IO.File.WriteAllText(sourcePath, sampleContent);
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, savePath);

            System.Console.WriteLine("Conversion completed. HTML saved at " + savePath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}