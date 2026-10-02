// Convert HTML to GIF and embed the resulting image as an inline attachment in an HTML email body.

using System;
using System.IO;
using System.Net.Mail;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.html");
            string htmlContent = "<html><body><h1>Hello, World!</h1><p>This is a sample HTML.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Define output GIF path
            string gifPath = Path.Combine(Directory.GetCurrentDirectory(), "output.gif");

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set image save options for GIF
            ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert HTML to GIF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, gifPath);

            // Create email with inline GIF
            MailMessage message = new MailMessage();
            message.From = new MailAddress("sender@example.com");
            message.To.Add(new MailAddress("recipient@example.com"));
            message.Subject = "HTML to GIF Inline Image Example";

            // HTML body referencing the inline image via CID
            string htmlBody = @"<html><body>
                                <h2>Embedded GIF Image</h2>
                                <img src=""cid:gifImage"" alt=""GIF Image"" />
                                </body></html>";

            AlternateView av = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");

            // Create linked resource for the GIF
            LinkedResource gifResource = new LinkedResource(gifPath);
            gifResource.ContentId = "gifImage";
            gifResource.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            av.LinkedResources.Add(gifResource);

            message.AlternateViews.Add(av);

            // For demonstration, output that the email is ready
            Console.WriteLine("Email prepared with inline GIF attachment.");
            Console.WriteLine("HTML file: " + htmlPath);
            Console.WriteLine("GIF file: " + gifPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}