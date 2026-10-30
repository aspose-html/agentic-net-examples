// Generate a PNG preview by converting the template to HTML and rendering the result to an image.

public class Program
{
    public static void Main()
    {
        try
        {
            string htmlCode = "<html><body><h1>Hello, {{name}}</h1></body></html>";
            string dataSource = "<root><name>World</name></root>";
            Aspose.Html.Converters.TemplateContentOptions options = new Aspose.Html.Converters.TemplateContentOptions(dataSource, Aspose.Html.Converters.TemplateContent.XML);
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData(options);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();
            Aspose.Html.HTMLDocument htmlDocument = Aspose.Html.Converters.Converter.ConvertTemplate(htmlCode, string.Empty, data, loadOptions);
            string outputPath = "preview.png";
            Aspose.Html.Rendering.Image.ImageRenderingOptions imgOptions = new Aspose.Html.Rendering.Image.ImageRenderingOptions();
            Aspose.Html.Rendering.Image.ImageDevice imgDevice = new Aspose.Html.Rendering.Image.ImageDevice(imgOptions, outputPath);
            htmlDocument.RenderTo(imgDevice);
            System.Console.WriteLine("PNG preview generated at: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}