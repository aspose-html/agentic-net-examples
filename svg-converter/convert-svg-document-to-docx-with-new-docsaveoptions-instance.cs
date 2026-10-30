// Convert an SVG document to DOCX by providing a new DocSaveOptions instance.

class Program
{
    static void Main()
    {
        try
        {
            string svgCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
            Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
            string outputPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "output.docx");
            Aspose.Html.Converters.Converter.ConvertSVG(svgCode, options, outputPath);
            System.Console.WriteLine("SVG converted to DOCX successfully: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}