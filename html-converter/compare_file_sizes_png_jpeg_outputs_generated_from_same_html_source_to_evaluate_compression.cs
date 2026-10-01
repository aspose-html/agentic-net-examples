// Compare file sizes of PNG and JPEG outputs generated from the same HTML source to evaluate compression.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string jpegPath = "output.jpg";
            string pngPath = "output.png";

            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1><p>Sample content for image conversion.</p></body></html>");
            }

            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            var pngOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, jpegOptions, jpegPath);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, pngOptions, pngPath);

            long jpegSize = new System.IO.FileInfo(jpegPath).Length;
            long pngSize = new System.IO.FileInfo(pngPath).Length;

            if (jpegSize > pngSize)
                System.Console.WriteLine("JPEG is larger than PNG.");
            else if (pngSize > jpegSize)
                System.Console.WriteLine("PNG is larger than JPEG.");
            else
                System.Console.WriteLine("JPEG and PNG have the same size.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}