// Render the resulting HTML document to a PNG image using the RenderTo method.

using System;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define HTML content and data source
            string htmlCode = "<html><body><input type='checkbox' checked='checked' /></body></html>";
            string dataSource = "<root></root>";

            // Prepare template options and data
            TemplateContentOptions templateOptions = new TemplateContentOptions(dataSource, TemplateContent.XML);
            TemplateData templateData = new TemplateData(templateOptions);
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Convert template to HTMLDocument
            HTMLDocument htmlDocument = Aspose.Html.Converters.Converter.ConvertTemplate(htmlCode, string.Empty, templateData, loadOptions);

            // Access the input element
            HTMLInputElement input = (HTMLInputElement)htmlDocument.GetElementsByTagName("input").First();
            Console.WriteLine("Checked: " + input.Checked);

            // Save the HTML document to a file
            string htmlOutputPath = "output.html";
            htmlDocument.Save(htmlOutputPath);
            Console.WriteLine("HTML saved to: " + htmlOutputPath);

            // Render the document to a PNG image
            ImageRenderingOptions imgRenderOptions = new ImageRenderingOptions();
            ImageDevice imgDevice = new ImageDevice(imgRenderOptions, "output.png");
            htmlDocument.RenderTo(imgDevice);
            Console.WriteLine("Rendered image saved to: output.png");

            // Direct HTML to PNG conversion using ConvertHTML
            ImageSaveOptions imgSaveOptions = new ImageSaveOptions(ImageFormat.Png);
            Aspose.Html.Converters.Converter.ConvertHTML(htmlCode, string.Empty, imgSaveOptions, "direct.png");
            Console.WriteLine("Direct conversion image saved to: direct.png");

            // Prepare a simple MHTML content
            string mhtmlContent = "From: <saved by Aspose.Html>\r\n" +
                                  "Content-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n" +
                                  "------=_NextPart_000_0000\r\n" +
                                  "Content-Type: text/html; charset=\"utf-8\"\r\n\r\n" +
                                  "<html><body><p>MHTML test</p></body></html>\r\n" +
                                  "------=_NextPart_000_0000--";
            byte[] mhtmlBytes = Encoding.UTF8.GetBytes(mhtmlContent);

            using (MemoryStream mhtmlStream = new MemoryStream(mhtmlBytes))
            {
                ImageSaveOptions mhtmlImgOptions = new ImageSaveOptions(ImageFormat.Png);
                Aspose.Html.Converters.Converter.ConvertMHTML(mhtmlStream, mhtmlImgOptions, "mhtml.png");
                Console.WriteLine("MHTML conversion image saved to: mhtml.png");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}