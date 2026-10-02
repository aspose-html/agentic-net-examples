// Convert HTML to GIF, read the generated image into a byte array, and output the byte array size for verification.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello, Aspose!</h1></body></html>");

            string outputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "output.gif");

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            byte[] imageBytes = System.IO.File.ReadAllBytes(outputPath);
            Console.WriteLine("Generated GIF byte array size: " + imageBytes.Length);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}